namespace Nebula.Shared.Api.Settings;

public class ApiSettings : IApiSettings
{
    public string? CoreApiUri { get; set; }
    public string Key { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int LifeTime { get; set; }
    public int ClockSkew { get; set; }
}