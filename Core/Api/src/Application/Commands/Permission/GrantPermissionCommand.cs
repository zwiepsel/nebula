using MediatR;
using Nebula.Core.Api.Application.Commands.Permission.Handlers;

namespace Nebula.Core.Api.Application.Commands.Permission;

/// <see cref="GrantPermissionHandler" />
public class GrantPermissionCommand : IRequest<Domain.Entities.Permission>
{
    public Domain.Entities.Permission Permission { get; }
    public Domain.Entities.Group Group { get; }

    public GrantPermissionCommand(Domain.Entities.Permission permission, Domain.Entities.Group group)
    {
        Permission = permission;
        Group = group;
    }
}