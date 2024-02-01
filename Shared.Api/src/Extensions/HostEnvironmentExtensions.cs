using Microsoft.Extensions.Hosting;

namespace Nebula.Shared.Api.Extensions;

public static class HostEnvironmentExtensions
{
    public static bool IsDevelopmentEnvironment(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.EnvironmentName.Contains(Constants.Environments.Development);
    }

    public static bool IsTestEnvironment(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment(Constants.Environments.Test);
    }

    public static bool IsAcceptanceEnvironment(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment(Constants.Environments.Acceptance);
    }

    public static bool IsProductionEnvironment(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment(Constants.Environments.Production);
    }
}