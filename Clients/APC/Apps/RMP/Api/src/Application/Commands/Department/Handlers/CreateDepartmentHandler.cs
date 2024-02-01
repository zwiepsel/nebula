using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department.Handlers;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, Domain.Entities.Department>
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IMapper mapper;

    public CreateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        this.departmentRepository = departmentRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Domain.Entities.Department>(request.DepartmentCreateModel);

        departmentRepository.Add(department);
        await departmentRepository.SaveChangesAsync(cancellationToken);

        return department;
    }
}