using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Queries.Role;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Models.Role;
using Nebula.Shared.Models.User;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Core.Api.Infrastructure.Controllers;

[ApiController]
[Route("role")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoleController : BaseController
{
    public RoleController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<UserViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = AdministratorRequirement.Name)]
    public async Task<IActionResult> Get()
    {
        var roles = await Mediator.Send(new GetAllRolesQuery());
        var roleViewModels = Mapper.Map<IEnumerable<RoleViewModel>>(roles);

        return Ok(roleViewModels);
    }

    [HttpGet]
    [Route("core")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<UserViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = AdministratorRequirement.Name)]
    public async Task<IActionResult> GetCoreRoles()
    {
        var roles = await Mediator.Send(new GetCoreRolesQuery());
        var roleViewModels = Mapper.Map<IEnumerable<RoleViewModel>>(roles);

        return Ok(roleViewModels);
    }

    [HttpGet]
    [Route("site")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<UserViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> GetSiteRoles()
    {
        var roles = await Mediator.Send(new GetSiteRolesQuery());
        var roleViewModels = Mapper.Map<IEnumerable<RoleViewModel>>(roles);

        return Ok(roleViewModels);
    }
}