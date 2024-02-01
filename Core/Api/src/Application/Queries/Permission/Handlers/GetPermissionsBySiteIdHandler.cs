using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Permission.Handlers;

public class GetPermissionsBySiteIdHandler : IRequestHandler<GetPermissionsBySiteIdQuery, IList<Domain.Entities.Permission>>
{
    private readonly IPermissionRepository permissionRepository;

    public GetPermissionsBySiteIdHandler(IPermissionRepository permissionRepository)
    {
        this.permissionRepository = permissionRepository;
    }

    public async Task<IList<Domain.Entities.Permission>> Handle(GetPermissionsBySiteIdQuery request, CancellationToken cancellationToken)
    {
        return await permissionRepository.FindBySiteId(request.SiteId, cancellationToken);
    }
}