using System.Linq;

namespace Nebula.Shared.Api.Settings;

public class ApplicationSettings : IApplicationSettings
{
    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string BaseVersion => Version.Split('.').First();
}