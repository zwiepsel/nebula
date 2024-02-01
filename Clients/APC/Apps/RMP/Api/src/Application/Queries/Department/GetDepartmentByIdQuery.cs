using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department;

/// <see cref="GetDepartmentByIdHandler" />
public class GetDepartmentByIdQuery : IRequest<Domain.Entities.Department?>
{
    public GetDepartmentByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}