using Nebula.Shared.Clients.Settings;
using Nebula.Shared.Constants;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Settings;

public class ApiSettings : IApiSettings
{
    public ApiSettings(string environment)
    {
        Uri = environment switch
        {
            Environments.Development => "https://localhost:5006",
            Environments.Test => "https://fcb-portal-api.nebula.test.businessone.app",
            Environments.Acceptance => "https://localhost:5006",
            Environments.Production => "https://fcb-portal-api.nebula.prod.businessone.app",
            _ => "https://localhost:5006"
        };
    }

    public string Uri { get; set; }
}