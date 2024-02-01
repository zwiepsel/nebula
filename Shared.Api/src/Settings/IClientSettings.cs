namespace Nebula.Shared.Api.Settings;

public interface IClientSettings
{
    public string Uri { get; set; }
    public string? BaseUri { get; set; }
}