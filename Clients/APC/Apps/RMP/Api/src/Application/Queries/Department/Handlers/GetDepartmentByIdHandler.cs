using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department.Handlers;

public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Domain.Entities.Department?>
{
    private readonly IDepartmentRepository departmentRepository;

    public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
    {
        this.departmentRepository = departmentRepository;
    }

    public async Task<Domain.Entities.Department?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await departmentRepository.FindById(request.Id);
    }
}