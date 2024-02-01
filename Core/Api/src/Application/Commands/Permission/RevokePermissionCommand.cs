using MediatR;
using Nebula.Core.Api.Application.Commands.Permission.Handlers;

namespace Nebula.Core.Api.Application.Commands.Permission;

/// <see cref="RevokePermissionHandler" />
public class RevokePermissionCommand : IRequest<Domain.Entities.Permission>
{
    public Domain.Entities.Permission Permission { get; }
    public Domain.Entities.Group Group { get; }

    public RevokePermissionCommand(Domain.Entities.Permission permission, Domain.Entities.Group group)
    {
        Permission = permission;
        Group = group;
    }
}