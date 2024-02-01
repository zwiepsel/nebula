using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="CreateRiskDepartmentHandler" />
public class CreateRiskDepartmentCommand : IRequest<Domain.Entities.Risk>
{
    public CreateRiskDepartmentCommand(Domain.Entities.Risk risk, Domain.Entities.Department department)
    {
        Risk = risk;
        Department = department;
    }

    public Domain.Entities.Risk Risk { get; }
    public Domain.Entities.Department Department { get; }
}