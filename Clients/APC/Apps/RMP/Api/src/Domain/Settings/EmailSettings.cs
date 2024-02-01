namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Settings;

public class EmailSettings
{
    public string FromName { get; set; } = null!;
    public string FromAddress { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public bool Ssl { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}