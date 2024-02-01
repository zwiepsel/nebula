using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department;

/// <see cref="UpdateDepartmentHandler" />
public class UpdateDepartmentCommand : IRequest<Domain.Entities.Department>
{
    public UpdateDepartmentCommand(Domain.Entities.Department department, DepartmentUpdateModel departmentUpdateModel)
    {
        Department = department;
        DepartmentUpdateModel = departmentUpdateModel;
    }

    public Domain.Entities.Department Department { get; }
    public DepartmentUpdateModel DepartmentUpdateModel { get; }
}