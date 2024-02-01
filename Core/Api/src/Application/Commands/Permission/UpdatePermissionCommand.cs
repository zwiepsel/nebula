using MediatR;
using Nebula.Core.Api.Application.Commands.Permission.Handlers;
using Nebula.Shared.Models.Permission;

namespace Nebula.Core.Api.Application.Commands.Permission;

/// <see cref="UpdatePermissionHandler" />
public class UpdatePermissionCommand : IRequest<Domain.Entities.Permission>
{
    public Domain.Entities.Permission Permission { get; }
    public PermissionUpdateModel PermissionUpdateModel { get; }

    public UpdatePermissionCommand(Domain.Entities.Permission permission, PermissionUpdateModel permissionUpdateModel)
    {
        Permission = permission;
        PermissionUpdateModel = permissionUpdateModel;
    }
}