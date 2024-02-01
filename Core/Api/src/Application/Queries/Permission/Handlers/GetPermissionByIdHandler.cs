using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Permission.Handlers;

public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, Domain.Entities.Permission?>
{
    private readonly IPermissionRepository permissionRepository;

    public GetPermissionByIdHandler(IPermissionRepository permissionRepository)
    {
        this.permissionRepository = permissionRepository;
    }

    public async Task<Domain.Entities.Permission?> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await permissionRepository.FindById(request.Id, cancellationToken);
    }
}