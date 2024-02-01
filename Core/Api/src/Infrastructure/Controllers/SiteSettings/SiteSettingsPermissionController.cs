using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.Permission;
using Nebula.Core.Api.Application.Queries.Permission;
using Nebula.Shared.Models.Permission;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Core.Api.Infrastructure.Controllers.SiteSettings;

[ApiController]
[Route("site-settings/{siteId:int}/permission")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
public class SiteSettingsPermissionController : Controller
{
    public SiteSettingsPermissionController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<PermissionViewModel>), StatusCodes.Status200OK)]
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

        var permissions = await Mediator.Send(new GetPermissionsBySiteIdQuery(siteId));
        var permissionViewModels = Mapper.Map<IList<PermissionViewModel>>(permissions);

        return Ok(permissionViewModels);
    }

    [HttpPost]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PermissionViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(int siteId, PermissionCreateModel permissionCreateModel)
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

        var permission = await Mediator.Send(new CreatePermissionCommand(currentSite, permissionCreateModel));
        var permissionViewModel = Mapper.Map<PermissionViewModel>(permission);

        return Ok(permissionViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PermissionViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int siteId, int id, PermissionUpdateModel permissionUpdateModel)
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

        var permission = await Mediator.Send(new GetPermissionByIdQuery(id));

        if (permission == null)
        {
            return NotFound();
        }

        if (permission.SiteId != siteId)
        {
            return Forbid();
        }

        permission = await Mediator.Send(new UpdatePermissionCommand(permission, permissionUpdateModel));
        var permissionViewModel = Mapper.Map<PermissionViewModel>(permission);

        return Ok(permissionViewModel);
    }
}