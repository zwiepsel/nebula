using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.SiteUser;
using Nebula.Core.Api.Application.Commands.User;
using Nebula.Core.Api.Application.Queries.Role;
using Nebula.Core.Api.Application.Queries.SiteUser;
using Nebula.Core.Api.Application.Queries.User;
using Nebula.Shared.Constants;
using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Models.User;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Core.Api.Infrastructure.Controllers.SiteSettings;

[ApiController]
[Route("site-settings/{siteId:int}/site-user")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
public class SiteSettingsSiteUserController : Controller
{
    public SiteSettingsSiteUserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<SiteUserViewModel>), StatusCodes.Status200OK)]
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

        var siteUsers = await Mediator.Send(new GetSiteUsersBySiteIdQuery(siteId));
        var siteUserViewModels = Mapper.Map<IList<SiteUserViewModel>>(siteUsers);

        return Ok(siteUserViewModels);
    }

    [HttpPost]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SiteUserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(int siteId, SiteUserCreateModel siteUserCreateModel)
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

        var user = await Mediator.Send(new GetUserByEmailAddressQuery(siteUserCreateModel.EmailAddress));

        if (user == null)
        {
            var coreUserRole = await Mediator.Send(new GetRoleByNameQuery(CoreRoles.User));

            var userCreateModel = new UserCreateModel
            {
                EmailAddress = siteUserCreateModel.EmailAddress,
                RoleId = coreUserRole.Id
            };

            user = await Mediator.Send(new CreateUserCommand(userCreateModel));
        }

        var siteUser = await Mediator.Send(new CreateSiteUserCommand(currentSite, user, siteUserCreateModel));
        var siteUserViewModel = Mapper.Map<SiteUserViewModel>(siteUser);

        return Ok(siteUserViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SiteUserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int siteId, int id, SiteUserUpdateModel siteUserUpdateModel)
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

        var siteUser = await Mediator.Send(new GetSiteUserByIdQuery(id));

        if (siteUser == null)
        {
            return NotFound();
        }

        if (siteUser.SiteId != siteId)
        {
            return Forbid();
        }

        siteUser = await Mediator.Send(new UpdateSiteUserCommand(siteUser, siteUserUpdateModel));
        var siteUserViewModel = Mapper.Map<SiteUserViewModel>(siteUser);

        return Ok(siteUserViewModel);
    }
}