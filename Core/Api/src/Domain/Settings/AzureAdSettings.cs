namespace Nebula.Core.Api.Domain.Settings;

public class AzureAdSettings
{
    public string AuthenticationMode { get; set; } = null!;
    public string AuthorityUri { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string TenantId { get; set; } = null!;
    public string[] Scope { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
}