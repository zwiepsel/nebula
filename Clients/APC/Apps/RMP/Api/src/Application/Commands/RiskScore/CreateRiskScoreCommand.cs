using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore;

/// <see cref="CreateRiskScoreHandler" />
public class CreateRiskScoreCommand : IRequest<Domain.Entities.RiskScore>
{
    public CreateRiskScoreCommand(RiskScoreCreateModel riskScoreCreateModel)
    {
        RiskScoreCreateModel = riskScoreCreateModel;
    }

    public RiskScoreCreateModel RiskScoreCreateModel { get; }
}