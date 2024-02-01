using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.Group;
using Nebula.Core.Api.Application.Commands.Permission;
using Nebula.Core.Api.Application.Queries.Group;
using Nebula.Core.Api.Application.Queries.Permission;
using Nebula.Shared.Models.Group;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Core.Api.Infrastructure.Controllers.SiteSettings;

[ApiController]
[Route("site-settings/{siteId:int}/group")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
public class SiteSettingsGroupController : Controller
{
    public SiteSettingsGroupController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<GroupViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Get(int siteId)
    {
        var currentSite = await GetCurrentSite();

        if (currentSite == null)
        {
            return NotFound();
        }

        if (currentSite.Id != siteId)
        {
            return Forbid();
        }

        var groups = await Mediator.Send(new GetGroupsBySiteIdQuery(siteId));
        var groupViewModels = Mapper.Map<IList<GroupViewModel>>(groups);

        return Ok(groupViewModels);
    }

    [HttpPost]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GroupViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(int siteId, GroupCreateModel groupCreateModel)
    {
        var currentSite = await GetCurrentSite();

        if (currentSite == null)
        {
            return NotFound();
        }

        if (currentSite.Id != siteId)
        {
            return Forbid();
        }

        var group = await Mediator.Send(new CreateGroupCommand(currentSite, groupCreateModel));
        var groupViewModel = Mapper.Map<GroupViewModel>(group);

        return Ok(groupViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GroupViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int siteId, int id, GroupUpdateModel groupUpdateModel)
    {
        var currentSite = await GetCurrentSite();

        if (currentSite == null)
        {
            return NotFound();
        }

        if (currentSite.Id != siteId)
        {
            return Forbid();
        }

        var group = await Mediator.Send(new GetGroupByIdQuery(id));

        if (group == null)
        {
            return NotFound();
        }

        if (group.SiteId != siteId)
        {
            return Forbid();
        }

        group = await Mediator.Send(new UpdateGroupCommand(group, groupUpdateModel));
        var groupViewModel = Mapper.Map<GroupViewModel>(group);

        return Ok(groupViewModel);
    }

    [HttpPut]
    [Route("{groupId:int}/grant/{permissionId:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GroupViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GrantPermission(int siteId, int groupId, int permissionId)
    {
        var currentSite = await GetCurrentSite();

        if (currentSite == null)
        {
            return NotFound();
        }

        if (currentSite.Id != siteId)
        {
            return Forbid();
        }

        var group = await Mediator.Send(new GetGroupByIdQuery(groupId));
        var permission = await Mediator.Send(new GetPermissionByIdQuery(permissionId));

        if (group == null || permission == null)
        {
            return NotFound();
        }

        if (group.SiteId != siteId || permission.SiteId != siteId || group.Permissions.Any(p => p.Id == permissionId))
        {
            return Forbid();
        }

        await Mediator.Send(new GrantPermissionCommand(permission, group));

        return Ok();
    }

    [HttpPut]
    [Route("{groupId:int}/revoke/{permissionId:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GroupViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RevokePermission(int siteId, int groupId, int permissionId)
    {
        var currentSite = await GetCurrentSite();

        if (currentSite == null)
        {
            return NotFound();
        }

        if (currentSite.Id != siteId)
        {
            return Forbid();
        }

        var group = await Mediator.Send(new GetGroupByIdQuery(groupId));
        var permission = await Mediator.Send(new GetPermissionByIdQuery(permissionId));

        if (group == null || permission == null)
        {
            return NotFound();
        }

        if (group.SiteId != siteId || permission.SiteId != siteId || group.Permissions.All(p => p.Id != permissionId))
        {
            return Forbid();
        }

        await Mediator.Send(new RevokePermissionCommand(permission, group));

        return Ok();
    }
}