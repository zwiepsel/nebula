using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Permission.Handlers;

public class GrantPermissionHandler : IRequestHandler<GrantPermissionCommand, Domain.Entities.Permission>
{
    private readonly IGroupRepository groupRepository;

    public GrantPermissionHandler(IGroupRepository groupRepository)
    {
        this.groupRepository = groupRepository;
    }

    public async Task<Domain.Entities.Permission> Handle(GrantPermissionCommand request, CancellationToken cancellationToken)
    {
        var group = request.Group;
        var permission = request.Permission;

        group.Permissions.Add(permission);

        groupRepository.Update(group);
        await groupRepository.SaveChangesAsync(cancellationToken);

        return permission;
    }
}