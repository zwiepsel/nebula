using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Nebula.Core.Api.Domain.Settings;

namespace Nebula.Core.Api.Domain.PowerBi;

public class AzureAdAuthenticationManager
{
    private readonly AzureAdSettings azureAdSettings;

    public AzureAdAuthenticationManager(AzureAdSettings azureAdSettings)
    {
        this.azureAdSettings = azureAdSettings;
    }

    public async Task<AuthenticationResult?> Authenticate()
    {
        var tenantSpecificUrl = azureAdSettings.AuthorityUri.Replace("organizations", azureAdSettings.TenantId);

        var clientApp = ConfidentialClientApplicationBuilder
            .Create(azureAdSettings.ClientId)
            .WithClientSecret(azureAdSettings.ClientSecret)
            .WithAuthority(tenantSpecificUrl)
            .Build();

        return await clientApp.AcquireTokenForClient(azureAdSettings.Scope).ExecuteAsync();
    }
}