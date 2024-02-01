using Nebula.Shared.Api.Settings;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Settings;

public class ClientSettings : IClientSettings
{
    public string Uri { get; set; } = null!;
    public string? BaseUri { get; set; }
}