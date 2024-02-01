using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskMitigationControl.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskMitigationControl;

/// <see cref="UpdateRiskMitigationControlHandler" />
public class UpdateRiskMitigationControlCommand : IRequest<Domain.Entities.RiskMitigationControl>
{
    public UpdateRiskMitigationControlCommand(Domain.Entities.RiskMitigationControl riskMitigationControl,
        RiskMitigationControlUpdateModel riskMitigationControlUpdateModel)
    {
        RiskMitigationControl = riskMitigationControl;
        RiskMitigationControlUpdateModel = riskMitigationControlUpdateModel;
    }

    public Domain.Entities.RiskMitigationControl RiskMitigationControl { get; }
    public RiskMitigationControlUpdateModel RiskMitigationControlUpdateModel { get; }
}