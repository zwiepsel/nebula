using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Nebula.Core.Api.Domain.Settings;
using Nebula.Shared.Models.PowerBi;

namespace Nebula.Core.Api.Domain.PowerBi;

public class PowerBiEmbedManager
{
    private readonly PowerBiSettings powerBiSettings;
    private readonly AzureAdAuthenticationManager azureAdAuthenticationManager;

    private PowerBIClient? powerBiClient;

    public PowerBiEmbedManager(PowerBiSettings powerBiSettings, AzureAdAuthenticationManager azureAdAuthenticationManager)
    {
        this.powerBiSettings = powerBiSettings;
        this.azureAdAuthenticationManager = azureAdAuthenticationManager;
    }

    public async Task<PowerBiEmbedViewModel> GetReportEmbedParameters(Guid workspaceId, Guid reportId)
    {
        var client = await GetClient();
        var report = await client.Reports.GetReportInGroupAsync(workspaceId, reportId);

        var powerBiReportViewModels = new List<PowerBiDataViewModel>
        {
            new()
            {
                Id = report.Id, Name = report.Name, EmbedUri = report.EmbedUrl
            }
        };

        var powerBiEmbedViewModel = new PowerBiEmbedViewModel
        {
            Type = "report",
            Data = powerBiReportViewModels,
            EmbedToken = await GetEmbedToken(report, workspaceId)
        };

        return powerBiEmbedViewModel;
    }

    public async Task<PowerBiEmbedViewModel> GetDashboardEmbedParameters(Guid workspaceId, Guid dashboardId)
    {
        var client = await GetClient();
        var dashboard = await client.Dashboards.GetDashboardInGroupAsync(workspaceId, dashboardId);

        var powerBiDashboardViewModels = new List<PowerBiDataViewModel>
        {
            new()
            {
                Id = dashboard.Id, Name = dashboard.DisplayName, EmbedUri = dashboard.EmbedUrl
            }
        };

        var powerBiEmbedViewModel = new PowerBiEmbedViewModel
        {
            Type = "dashboard",
            Data = powerBiDashboardViewModels,
            EmbedToken = await GetEmbedToken(dashboard, workspaceId)
        };

        return powerBiEmbedViewModel;
    }

    private async Task<PowerBIClient> GetClient()
    {
        if (powerBiClient == null)
        {
            var authenticationResult = await azureAdAuthenticationManager.Authenticate();
            var tokenCredentials = new TokenCredentials(authenticationResult!.AccessToken, "Bearer");

            powerBiClient = new PowerBIClient(new Uri(powerBiSettings.BaseUri), tokenCredentials);
        }

        return powerBiClient;
    }

    private async Task<PowerBiEmbedTokenViewModel> GetEmbedToken(Report report, Guid targetWorkspaceId)
    {
        var client = await GetClient();
        var dataset = (await client.Datasets.GetDatasetInGroupWithHttpMessagesAsync(targetWorkspaceId, report.DatasetId)).Body;

        var tokenRequest = new GenerateTokenRequestV2
        {
            TargetWorkspaces = new List<GenerateTokenRequestV2TargetWorkspace> { new(targetWorkspaceId) },
            Reports = new List<GenerateTokenRequestV2Report> { new(report.Id) },
            Datasets = new List<GenerateTokenRequestV2Dataset>
            {
                new(dataset.Id)
            }
        };

        if (dataset.IsEffectiveIdentityRequired == true)
        {
            tokenRequest.Identities = new List<EffectiveIdentity>
            {
                new()
                {
                    Username = "Nebula PowerBI embedding",
                    Roles = new List<string>
                    {
                        "Admin"
                    },
                    Datasets = new List<string>
                    {
                        new(dataset.Id)
                    }
                }
            };
        }

        var embedToken = await client.EmbedToken.GenerateTokenAsync(tokenRequest);

        var powerBiEmbedTokenViewModel = new PowerBiEmbedTokenViewModel
        {
            Token = embedToken.Token,
            TokenId = embedToken.TokenId,
            Expiration = embedToken.Expiration
        };

        return powerBiEmbedTokenViewModel;
    }

    private async Task<PowerBiEmbedTokenViewModel> GetEmbedToken(Dashboard dashboard, Guid targetWorkspaceId)
    {
        var client = await GetClient();
        var tokenRequest = new GenerateTokenRequest
        {
            AccessLevel = TokenAccessLevel.View
        };

        var embedToken = await client.Dashboards.GenerateTokenInGroupAsync(targetWorkspaceId, dashboard.Id, tokenRequest);

        var powerBiEmbedTokenViewModel = new PowerBiEmbedTokenViewModel
        {
            Token = embedToken.Token,
            TokenId = embedToken.TokenId,
            Expiration = embedToken.Expiration
        };

        return powerBiEmbedTokenViewModel;
    }
}