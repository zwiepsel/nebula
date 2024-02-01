using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using Nebula.Shared.Clients.Security;
using Nebula.Shared.Clients.Settings;

namespace Nebula.Shared.Clients.Data;

public class CoreApi : BaseApi
{
    public CoreApi(ILogger<CoreApi> logger,
        ApiTokenManager apiTokenManager,
        AuthenticationStateProvider authenticationStateProvider,
        NavigationManager navigationManager,
        IWebAssemblyHostEnvironment webAssemblyHostEnvironment,
        CoreApiSettings coreApiSettings,
        CoreApiSettings appApiSettings,
        bool coreApi = true)
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