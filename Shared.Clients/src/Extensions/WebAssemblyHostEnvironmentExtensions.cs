using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Nebula.Shared.Constants;

namespace Nebula.Shared.Clients.Extensions;

public static class WebAssemblyHostEnvironmentExtensions
{
    public static bool IsDevelopmentEnvironment(this IWebAssemblyHostEnvironment hostingEnvironment)
    {
        return hostingEnvironment.IsEnvironment(Environments.Development);
    }

    public static bool IsTestEnvironment(this IWebAssemblyHostEnvironment hostingEnvironment)
    {
        return hostingEnvironment.IsEnvironment(Environments.Test);
    }

    public static bool IsAcceptanceEnvironment(this IWebAssemblyHostEnvironment hostingEnvironment)
    {
        return hostingEnvironment.IsEnvironment(Environments.Acceptance);
    }

    public static bool IsProductionEnvironment(this IWebAssemblyHostEnvironment hostingEnvironment)
    {
        return hostingEnvironment.IsEnvironment(Environments.Production);
    }
}