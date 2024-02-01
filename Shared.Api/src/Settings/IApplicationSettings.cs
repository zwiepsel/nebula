namespace Nebula.Shared.Api.Settings;

public interface IApplicationSettings
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string BaseVersion { get; }
}