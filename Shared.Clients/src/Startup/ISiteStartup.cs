using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Nebula.Shared.Clients.Startup;

public interface ISiteStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder);
}