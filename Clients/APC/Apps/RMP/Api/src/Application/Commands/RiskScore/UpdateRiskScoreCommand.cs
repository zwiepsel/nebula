using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore;

/// <see cref="UpdateRiskScoreHandler" />
public class UpdateRiskScoreCommand : IRequest<Domain.Entities.RiskScore>
{
    public UpdateRiskScoreCommand(Domain.Entities.RiskScore riskScore, RiskScoreUpdateModel riskScoreUpdateModel)
    {
        RiskScore = riskScore;
        RiskScoreUpdateModel = riskScoreUpdateModel;
    }

    public Domain.Entities.RiskScore RiskScore { get; }
    public RiskScoreUpdateModel RiskScoreUpdateModel { get; }
}