using MediatR;
using Nebula.Core.Api.Application.Commands.Permission.Handlers;
using Nebula.Shared.Models.Permission;

namespace Nebula.Core.Api.Application.Commands.Permission;

/// <see cref="CreatePermissionHandler" />
public class CreatePermissionCommand : IRequest<Domain.Entities.Permission>
{
    public Domain.Entities.Site Site { get; }
    public PermissionCreateModel? PermissionCreateModel { get; }

    public CreatePermissionCommand(Domain.Entities.Site site, PermissionCreateModel permissionCreateModel)
    {
        Site = site;
        PermissionCreateModel = permissionCreateModel;
    }
}