using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department.Handlers;

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Domain.Entities.Department>
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IMapper mapper;

    public UpdateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        this.departmentRepository = departmentRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = mapper.Map(request.DepartmentUpdateModel, request.Department);

        departmentRepository.Update(department);
        await departmentRepository.SaveChangesAsync(cancellationToken);

        return department;
    }
}