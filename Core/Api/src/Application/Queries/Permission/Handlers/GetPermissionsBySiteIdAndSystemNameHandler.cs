using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Permission.Handlers;

public class GetPermissionBySiteIdAndSystemNameHandler : IRequestHandler<GetPermissionBySiteIdAndSystemNameQuery, Domain.Entities.Permission?>
{
    private readonly IPermissionRepository permissionRepository;

    public GetPermissionBySiteIdAndSystemNameHandler(IPermissionRepository permissionRepository)
    {
        this.permissionRepository = permissionRepository;
    }

    public async Task<Domain.Entities.Permission?> Handle(GetPermissionBySiteIdAndSystemNameQuery request, CancellationToken cancellationToken)
    {
        return await permissionRepository.FindBySiteIdAndSystemName(request.SiteId, request.SystemName, cancellationToken);
    }
}