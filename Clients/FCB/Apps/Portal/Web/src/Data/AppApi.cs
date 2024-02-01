using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using Nebula.Clients.FCB.Apps.Portal.Web.Settings;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Security;
using Nebula.Shared.Clients.Settings;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Data;

public class AppApi : BaseApi
{
    public AppApi(ILogger<AppApi> logger,
        ApiTokenManager apiTokenManager,
        AuthenticationStateProvider authenticationStateProvider,
        NavigationManager navigationManager,
        IWebAssemblyHostEnvironment webAssemblyHostEnvironment,
        CoreApiSettings coreApiSettings,
        ApiSettings appApiSettings, bool coreApi = false)
        : base(logger,
            apiTokenManager,
            authenticationStateProvider,
            navigationManager,
            webAssemblyHostEnvironment,
            coreApiSettings,
            appApiSettings,
            coreApi)
    {
    }
}