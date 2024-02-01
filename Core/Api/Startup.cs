using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Core.Api.Domain.PowerBi;
using Nebula.Core.Api.Domain.Repositories;
using Nebula.Core.Api.Domain.Security;
using Nebula.Core.Api.Domain.Settings;
using Nebula.Core.Api.Domain.Validation;
using Nebula.Core.Api.Infrastructure.Data;
using Nebula.Core.Api.Infrastructure.Repositories;
using Nebula.Core.Shared.Validation;
using Nebula.Shared.Api.Startup;
using Nebula.Shared.Constants;
using Nebula.Shared.Security.Authorization;
using Nebula.Shared.Security.Authorization.Handlers;

namespace Nebula.Core.Api;

public class Startup : BaseStartup<Startup, DatabaseContext, Shared.Shared, ClientSettings>
{
    public Startup(IConfiguration configuration) : base(configuration, configuration.GetSection("Client").Get<ClientSettings>())
    {
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureDefaultServices(serviceCollection);

        serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = PasswordRequirements.MinimumLength;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
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
                    OnTokenValidated = context =>
                    {
                        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                        var userId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                        var user = userManager.FindByIdAsync(userId).Result;

                        if (user == null)
                        {
                            context.Fail($"User with ID {userId} does not exist.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy(AdministratorRequirement.Name, policy => policy.Requirements.Add(new AdministratorRequirement()));
                options.AddPolicy(SiteAdministratorRequirement.Name, policy => policy.Requirements.Add(new SiteAdministratorRequirement()));
            }
        );

        // Authorization services.
        serviceCollection.AddScoped<IAuthorizationHandler, AdministratorRequirementHandler>();
        serviceCollection.AddScoped<IAuthorizationHandler, SiteAdministratorRequirementHandler>();

        // Configuration services.
        serviceCollection.AddSingleton(ClientSettings);
        serviceCollection.AddSingleton(Configuration.GetSection("AzureAd").Get<AzureAdSettings>());
        serviceCollection.AddSingleton(Configuration.GetSection("PowerBi").Get<PowerBiSettings>());

        // Data services.
        serviceCollection.AddScoped<IDatabaseContext, DatabaseContext>();

        // Security services.
        serviceCollection.AddScoped<PasswordManager, PasswordManager>();

        // Validation services.
        serviceCollection.AddScoped<IRemoteDataValidator, RemoteDataValidator>();

        // Repository services.
        serviceCollection.AddScoped<IAppRepository, AppRepository>();
        serviceCollection.AddScoped<IClientRepository, ClientRepository>();
        serviceCollection.AddScoped<IGroupRepository, GroupRepository>();
        serviceCollection.AddScoped<IPermissionRepository, PermissionRepository>();
        serviceCollection.AddScoped<ISiteRepository, SiteRepository>();
        serviceCollection.AddScoped<ISiteUserRepository, SiteUserRepository>();

        // PowerBi services.
        serviceCollection.AddScoped<PowerBiEmbedManager, PowerBiEmbedManager>();
        serviceCollection.AddScoped<AzureAdAuthenticationManager, AzureAdAuthenticationManager>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {
        ConfigureDefaults(applicationBuilder, webHostEnvironment);
    }
}