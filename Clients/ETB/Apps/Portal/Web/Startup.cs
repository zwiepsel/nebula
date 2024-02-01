using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Shared.Clients.Startup;

namespace Nebula.Clients.ETB.Apps.Portal.Web;

public class Startup : IAppStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        webAssemblyHostBuilder.Services.AddAutoMapper(typeof(App));
    }
}