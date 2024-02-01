using System;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nebula.Core.Shared.Validation;
using Nebula.Core.Web.Extensions;
using Nebula.Core.Web.Repositories;
using Nebula.Core.Web.Repositories.SiteSettings;
using Nebula.Core.Web.Settings;
using Nebula.Core.Web.Validation;
using Nebula.Shared.Clients.Cache;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Localization;
using Nebula.Shared.Clients.Security;
using Nebula.Shared.Clients.Security.Authorization;
using Nebula.Shared.Clients.Security.Authorization.Handlers;
using Nebula.Shared.Clients.Settings;
using Nebula.Shared.Clients.State;
using Nebula.Shared.Security.Authorization;
using Nebula.Shared.Security.Authorization.Handlers;
using Sentry;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Nebula.Core.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var webAssemblyHostBuilder = WebAssemblyHostBuilder.CreateDefault(args);
        var sentryOptions = webAssemblyHostBuilder.Configuration.GetSection("Sentry").Get<SentryOptions?>();

        if (sentryOptions != null)
        {
            sentryOptions.Environment = webAssemblyHostBuilder.HostEnvironment.Environment;
            SentrySdk.Init(sentryOptions);
        }

        try
        {
            webAssemblyHostBuilder.Logging.AddSentry(options => options.InitializeSdk = false);

            webAssemblyHostBuilder.RootComponents.Add<App>("#app");
            webAssemblyHostBuilder.RootComponents.Add<HeadOutlet>("head::after");

            webAssemblyHostBuilder.Services.AddLocalization();
            AddAuthorization(webAssemblyHostBuilder);

            webAssemblyHostBuilder.Services.AddSyncfusionBlazor(options => options.IgnoreScriptIsolation = true);
            webAssemblyHostBuilder.Services.AddAutoMapper(typeof(Program));
            webAssemblyHostBuilder.Services.AddBlazoredLocalStorage(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            webAssemblyHostBuilder.Services.AddBlazoredModal();
            webAssemblyHostBuilder.Services.AddBlazoredToast();

            var applicationSettings = webAssemblyHostBuilder.Configuration.GetSection("Application").Get<ApplicationSettings>();
            var apiSettings = webAssemblyHostBuilder.Configuration.GetSection("Api").Get<CoreApiSettings>();

            SyncfusionLicenseProvider.RegisterLicense(applicationSettings.SyncfusionLicenseKey);

            // State services.
            webAssemblyHostBuilder.Services.AddScoped<AppState, AppState>();

            // Translation services.
            webAssemblyHostBuilder.Services.AddScoped(typeof(ILocalizer<>), typeof(Localizer<>));

            // Cache services.
            webAssemblyHostBuilder.Services.AddScoped<ICache, LocalStorageCacheProvider>();

            // Authentication services.
            webAssemblyHostBuilder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            // Data services.
            webAssemblyHostBuilder.Services.AddScoped<CoreApi, CoreApi>();

            // Repository services.
            webAssemblyHostBuilder.Services.AddScoped<AppRepository, AppRepository>();
            webAssemblyHostBuilder.Services.AddScoped<ClientRepository, ClientRepository>();
            webAssemblyHostBuilder.Services.AddScoped<RoleRepository, RoleRepository>();
            webAssemblyHostBuilder.Services.AddScoped<SiteRepository, SiteRepository>();
            webAssemblyHostBuilder.Services.AddScoped<UserRepository, UserRepository>();

            // Site settings repository services.
            webAssemblyHostBuilder.Services.AddScoped<SiteSettingsGroupRepository, SiteSettingsGroupRepository>();
            webAssemblyHostBuilder.Services.AddScoped<SiteSettingsPermissionRepository, SiteSettingsPermissionRepository>();
            webAssemblyHostBuilder.Services.AddScoped<SiteSettingsSiteUserRepository, SiteSettingsSiteUserRepository>();

            // Security services.
            webAssemblyHostBuilder.Services.AddScoped<ApiTokenManager, ApiTokenManager>();
            webAssemblyHostBuilder.Services.AddScoped<IAuthorizationChecker, AuthorizationChecker>();
            webAssemblyHostBuilder.Services.AddScoped<SecurityManager, SecurityManager>();

            // Validation services.
            webAssemblyHostBuilder.Services.AddScoped<IRemoteDataValidator, RemoteDataValidator>();

            // Setting services.
            webAssemblyHostBuilder.Services.AddSingleton(applicationSettings);
            webAssemblyHostBuilder.Services.AddSingleton(apiSettings);

            // Configure the sites.
            await webAssemblyHostBuilder.ConfigureSites(apiSettings);

            var webAssemblyHost = webAssemblyHostBuilder.Build();

            var appState = webAssemblyHost.Services.GetRequiredService<AppState>();
            var currentCulture = await appState.GetCurrentCulture();

            CultureInfo.DefaultThreadCurrentCulture = currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = currentCulture;

            await webAssemblyHost.RunAsync();
        }
        catch (Exception exception)
        {
            SentrySdk.CaptureException(exception);
            await SentrySdk.FlushAsync(TimeSpan.FromSeconds(3));

            throw;
        }
    }

    private static void AddAuthorization(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        webAssemblyHostBuilder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(SiteRequirement.Name, policy => policy.Requirements.Add(new SiteRequirement()));
                options.AddPolicy(AdministratorRequirement.Name, policy => policy.Requirements.Add(new AdministratorRequirement()));
                options.AddPolicy(SiteAdministratorRequirement.Name, policy => policy.Requirements.Add(new SiteAdministratorRequirement()));
            }
        );

        // Authorization services.
        webAssemblyHostBuilder.Services.AddScoped<IAuthorizationHandler, SiteRequirementHandler>();
        webAssemblyHostBuilder.Services.AddScoped<IAuthorizationHandler, AdministratorRequirementHandler>();
        webAssemblyHostBuilder.Services.AddScoped<IAuthorizationHandler, SiteAdministratorRequirementHandler>();
    }
}