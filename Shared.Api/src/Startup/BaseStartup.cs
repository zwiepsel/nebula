using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nebula.Shared.Api.Console.Commands;
using Nebula.Shared.Api.Data;
using Nebula.Shared.Api.Extensions;
using Nebula.Shared.Api.Security.Authorization;
using Nebula.Shared.Api.Security.Authorization.Handlers;
using Nebula.Shared.Api.Settings;
using Nebula.Shared.Api.Utilities;
using Nebula.Shared.Security.Authorization;
using Nebula.Shared.Security.Authorization.Handlers;

namespace Nebula.Shared.Api.Startup;

public abstract class BaseStartup<TStartup, TDatabaseContext, TValidationAssemblyType, TClientSettings>
    where TDatabaseContext : DbContext, IBaseDatabaseContext
    where TClientSettings : IClientSettings
{
    public BaseStartup(IConfiguration configuration, TClientSettings clientSettings)
    {
        Configuration = configuration;
        ClientSettings = clientSettings;
        ApiSettings = Configuration.GetSection("API").Get<ApiSettings>();
        ApplicationSettings = Configuration.GetSection("Application").Get<ApplicationSettings>();
    }

    protected IConfiguration Configuration { get; }
    protected ApiSettings ApiSettings { get; set; }
    protected ApplicationSettings ApplicationSettings { get; set; }
    protected TClientSettings ClientSettings { get; set; }

    protected void ConfigureDefaultServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<TDatabaseContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("Application"));
            options.UseLazyLoadingProxies();
        });

        serviceCollection.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<TValidationAssemblyType>();
                options.DisableDataAnnotationsValidation = true;
            });
        serviceCollection.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.FullName);
            options.SwaggerDoc($"v{ApplicationSettings.BaseVersion}", new OpenApiInfo
            {
                Title = ApplicationSettings.Name,
                Version = $"v{ApplicationSettings.Version}"
            });
        });

        serviceCollection.AddMediatR(typeof(TStartup).GetTypeInfo().Assembly);
        serviceCollection.AddAutoMapper(typeof(TStartup));
        serviceCollection.AddCors();
        serviceCollection.AddMvc();
        serviceCollection.AddSignalR();

        // Configuration services.
        serviceCollection.AddSingleton(ApiSettings);
        serviceCollection.AddSingleton(ApplicationSettings);

        // Security services.
        serviceCollection.AddScoped<IAuthorizationChecker, AuthorizationChecker>();

        // Console command services.
        serviceCollection.AddScoped<UpdateDatabaseCommand<TDatabaseContext>, UpdateDatabaseCommand<TDatabaseContext>>();
    }

    protected void ConfigureDefaultAppServices(IServiceCollection serviceCollection)
    {
        ConfigureDefaultServices(serviceCollection);
        AddAppAuthentication(serviceCollection);
        AddAppAuthorization(serviceCollection);
    }

    protected void ConfigureDefaults(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {
        if (webHostEnvironment.IsDevelopmentEnvironment())
            applicationBuilder.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        if (webHostEnvironment.IsDevelopmentEnvironment() || webHostEnvironment.IsTestEnvironment())
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint($"/swagger/v{ApplicationSettings.BaseVersion}/swagger.json", ApplicationSettings.Name);
            });
            applicationBuilder.UseReDoc(options =>
            {
                options.RoutePrefix = "redoc";
                options.DocumentTitle = ApplicationSettings.Name;
                options.SpecUrl = $"/swagger/v{ApplicationSettings.BaseVersion}/swagger.json";
            });
        }

        applicationBuilder.UseHsts();
        applicationBuilder.UseHttpsRedirection();
        applicationBuilder.UseRouting();

        if (webHostEnvironment.IsTestEnvironment() || webHostEnvironment.IsAcceptanceEnvironment() || webHostEnvironment.IsProductionEnvironment())
        {
            if (ClientSettings.BaseUri == null)
            {
                applicationBuilder.UseCors(builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains().WithOrigins(ClientSettings.Uri).AllowAnyMethod()
                        .AllowAnyHeader().AllowCredentials();
                });
            }
            else
            {
                applicationBuilder.UseCors(builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains().WithOrigins(ClientSettings.Uri, ClientSettings.BaseUri)
                        .AllowAnyMethod()
                        .AllowAnyHeader().AllowCredentials();
                });
            }
        }

        applicationBuilder.UseAuthorization();
        applicationBuilder.UseAuthentication();
        applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private void AddAppAuthentication(IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ApiSettings.Issuer,
                    ValidAudience = ApiSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSettings.Key)),
                    ClockSkew = TimeSpan.FromSeconds(ApiSettings.ClockSkew)
                };

                options.Events = new JwtBearerEvents
                {
                    // If the request is a WebSocket request retrieve the token from the query.
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/ws"))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    },
                    // Check if the user in the claim is valid.
                    OnTokenValidated = async context =>
                    {
                        if (context.SecurityToken is not JwtSecurityToken accessToken)
                        {
                            context.Fail("Invalid access token.");

                            return;
                        }

                        CoreApiHttpClient.Create(ApiSettings.CoreApiUri!, accessToken.RawData);

                        var response = await CoreApiHttpClient.GetResponse("me/user");

                        if (!response.IsSuccessStatusCode)
                        {
                            context.Fail("User does not exist.");
                        }
                    }
                };
            });
    }

    private void AddAppAuthorization(IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy(SiteRequirement.Name, policy => policy.Requirements.Add(new SiteRequirement()));
            options.AddPolicy(AdministratorRequirement.Name, policy => policy.Requirements.Add(new AdministratorRequirement()));
            options.AddPolicy(SiteAdministratorRequirement.Name, policy => policy.Requirements.Add(new SiteAdministratorRequirement()));
        });

        // Authorization services.
        serviceCollection.AddScoped<IAuthorizationHandler, SiteRequirementHandler>();
        serviceCollection.AddScoped<IAuthorizationHandler, AdministratorRequirementHandler>();
        serviceCollection.AddScoped<IAuthorizationHandler, SiteAdministratorRequirementHandler>();
    }
}