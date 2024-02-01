using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="UpdateRiskHandler" />
public class UpdateRiskCommand : IRequest<Domain.Entities.Risk>
{
    public Domain.Entities.Risk Risk { get; }
    public RiskUpdateModel RiskUpdateModel { get; }

    public UpdateRiskCommand(Domain.Entities.Risk risk, RiskUpdateModel riskUpdateModel)
    {
        Risk = risk;
        RiskUpdateModel = riskUpdateModel;
    }
}