using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department.Handlers;

public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<Domain.Entities.Department>>
{
    private readonly IDepartmentRepository departmentRepository;

    public GetAllDepartmentsHandler(IDepartmentRepository departmentRepository)
    {
        this.departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Department>> Handle(GetAllDepartmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await departmentRepository.FindAll(false, cancellationToken);
    }
}