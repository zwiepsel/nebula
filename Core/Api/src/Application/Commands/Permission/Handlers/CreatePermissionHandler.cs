using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Permission.Handlers;

public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, Domain.Entities.Permission>
{
    private readonly IPermissionRepository permissionRepository;
    private readonly IMapper mapper;

    public CreatePermissionHandler(IPermissionRepository permissionRepository, IMapper mapper)
    {
        this.permissionRepository = permissionRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = mapper.Map<Domain.Entities.Permission>(request.PermissionCreateModel);

        permission.SiteId = request.Site.Id;

        permissionRepository.Add(permission);
        await permissionRepository.SaveChangesAsync(cancellationToken);

        return permissionRepository.Refresh(permission);
    }
}