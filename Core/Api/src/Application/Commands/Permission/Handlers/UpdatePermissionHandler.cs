using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Permission.Handlers;

public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Domain.Entities.Permission>
{
    private readonly IPermissionRepository permissionRepository;
    private readonly IMapper mapper;

    public UpdatePermissionHandler(IPermissionRepository permissionRepository, IMapper mapper)
    {
        this.permissionRepository = permissionRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = mapper.Map(request.PermissionUpdateModel, request.Permission);

        permissionRepository.Update(permission);
        await permissionRepository.SaveChangesAsync(cancellationToken);

        return permission;
    }
}