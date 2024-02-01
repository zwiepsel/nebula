namespace Nebula.Shared.Api.Settings;

public interface IApiSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int LifeTime { get; set; }
    public int ClockSkew { get; set; }
}