using Nebula.Shared.Clients.Settings;
using Nebula.Shared.Constants;

namespace Nebula.Clients.APC.Apps.RMP.Web.Settings;

public class ApiSettings : IApiSettings
{
    public ApiSettings(string environment)
    {
        Uri = environment switch
        {
            Environments.Development => "https://localhost:5005",
            Environments.Test => "https://apc-rmp-api.nebula.test.businessone.app",
            Environments.Acceptance => "https://localhost:5005",
            Environments.Production => "https://apc-rmp-api.nebula.prod.businessone.app",
            _ => "https://localhost:5005"
        };
    }

    public string Uri { get; set; }
}