using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="DeleteRiskPossibleOptimizationHandler" />
public class DeleteRiskPossibleOptimizationCommand : IRequest<Domain.Entities.Risk>
{
    public DeleteRiskPossibleOptimizationCommand(Domain.Entities.Risk risk, Domain.Entities.MitigationControl department)
    {
        Risk = risk;
        MitigationControl = department;
    }

    public Domain.Entities.Risk Risk { get; }
    public Domain.Entities.MitigationControl MitigationControl { get; }
}