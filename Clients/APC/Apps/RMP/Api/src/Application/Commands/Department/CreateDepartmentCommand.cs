using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department;

/// <see cref="CreateDepartmentHandler" />
public class CreateDepartmentCommand : IRequest<Domain.Entities.Department>
{
    public CreateDepartmentCommand(DepartmentCreateModel departmentCreateModel)
    {
        DepartmentCreateModel = departmentCreateModel;
    }

    public DepartmentCreateModel DepartmentCreateModel { get; }
}