using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="DeleteRiskDepartmentHandler" />
public class DeleteRiskDepartmentCommand : IRequest<Domain.Entities.Risk>
{
    public DeleteRiskDepartmentCommand(Domain.Entities.Risk risk, Domain.Entities.Department department)
    {
        Risk = risk;
        Department = department;
    }

    public Domain.Entities.Risk Risk { get; }
    public Domain.Entities.Department Department { get; }
}