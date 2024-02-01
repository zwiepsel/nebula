using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Nebula.Shared.Clients.Startup;

public interface IAppStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder);
}