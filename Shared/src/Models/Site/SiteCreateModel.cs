namespace Nebula.Shared.Models.Site;

public class SiteCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int? Port { get; set; }
    public bool AllowPublicRegistration { get; set; }
    public int ClientId { get; set; }
}