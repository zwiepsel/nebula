using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="CreateRiskPossibleOptimizationHandler" />
public class CreateRiskPossibleOptimizationCommand : IRequest<Domain.Entities.RiskPossibleOptimization>
{
    public CreateRiskPossibleOptimizationCommand(Domain.Entities.Risk risk,
        Domain.Entities.MitigationControl mitigationControl,
        MitigationControlLinkModel model)
    {
        Risk = risk;
        MitigationControl = mitigationControl;
        Model = model;
    }

    public Domain.Entities.Risk Risk { get; }
    public Domain.Entities.MitigationControl MitigationControl { get; }
    public MitigationControlLinkModel Model { get; }
}