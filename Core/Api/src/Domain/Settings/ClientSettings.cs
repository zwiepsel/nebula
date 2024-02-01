using Nebula.Shared.Api.Settings;

namespace Nebula.Core.Api.Domain.Settings;

public class ClientSettings : IClientSettings
{
    public string PasswordResetUri { get; set; } = null!;
    public string Uri { get; set; } = null!;
    public string? BaseUri { get; set; }
}