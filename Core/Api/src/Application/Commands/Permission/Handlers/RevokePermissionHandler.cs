using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Permission.Handlers;

public class RevokePermissionHandler : IRequestHandler<RevokePermissionCommand, Domain.Entities.Permission>
{
    private readonly IGroupRepository groupRepository;

    public RevokePermissionHandler(IGroupRepository groupRepository)
    {
        this.groupRepository = groupRepository;
    }

    public async Task<Domain.Entities.Permission> Handle(RevokePermissionCommand request, CancellationToken cancellationToken)
    {
        var group = request.Group;
        var permission = request.Permission;

        group.Permissions.Remove(permission);

        groupRepository.Update(group);
        await groupRepository.SaveChangesAsync(cancellationToken);

        return permission;
    }
}