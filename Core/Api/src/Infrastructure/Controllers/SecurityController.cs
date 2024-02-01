using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.Security;
using Nebula.Core.Api.Application.Commands.SiteUser;
using Nebula.Core.Api.Application.Commands.User;
using Nebula.Core.Api.Application.Queries.Role;
using Nebula.Core.Api.Application.Queries.Security;
using Nebula.Core.Api.Application.Queries.Site;
using Nebula.Core.Api.Application.Queries.User;
using Nebula.Shared.Constants;
using Nebula.Shared.Models.Security;
using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Api.Infrastructure.Controllers;

[ApiController]
[Route("security")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SecurityController : Controller
{
    public SecurityController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("sign-in")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiTokenModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignIn(SignInModel signInModel)
    {
        var user = await Mediator.Send(new GetUserByEmailAddressQuery(signInModel.EmailAddress));
        var site = await Mediator.Send(new GetSiteByIdQuery(signInModel.SiteId));

        if (user != null && site != null)
        {
            // System users are never allowed to sign in.
            if (user.IsInRole(CoreRoles.System))
            {
                return Forbid();
            }

            // Administrators are always allowed to sign in.
            if (user.IsInRole(CoreRoles.Administrator) && await Mediator.Send(new IsValidPasswordQuery(user, signInModel.Password)))
            {
                return Ok(await Mediator.Send(new GetApiTokenQuery(user, site)));
            }

            // Users are allowed to sign in provided that they have access to the site.
            if (user.IsInRole(CoreRoles.User))
            {
                var siteUser = user.SiteUsers.FirstOrDefault(su => su.SiteId == site.Id);

                // User has a valid password and has access to the site.
                if (siteUser != null && await Mediator.Send(new IsValidPasswordQuery(siteUser, signInModel.Password)))
                {
                    return Ok(await Mediator.Send(new GetApiTokenQuery(user, site, siteUser)));
                }
            }
        }

        return Forbid();
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("register-public")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SiteUserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RegisterPublic(PublicRegisterModel publicRegisterModel)
    {
        var site = await Mediator.Send(new GetSiteByIdQuery(publicRegisterModel.SiteId));

        if (site == null)
        {
            return NotFound();
        }

        // Only allow public registrations on sites that have it enabled.
        if (site.AllowPublicRegistration)
        {
            var user = await Mediator.Send(new GetUserByEmailAddressQuery(publicRegisterModel.EmailAddress));

            // No user, create a user and site user.
            if (user == null)
            {
                var coreUserRole = await Mediator.Send(new GetRoleByNameQuery(CoreRoles.User));

                var userCreateModel = new UserCreateModel
                {
                    EmailAddress = publicRegisterModel.EmailAddress,
                    RoleId = coreUserRole.Id
                };

                user = await Mediator.Send(new CreateUserCommand(userCreateModel));
            }
            // User exists and already has a site user.
            else if (user.SiteUsers.Any(siteUser => siteUser.SiteId == site.Id))
            {
                return Forbid();
            }

            var siteUser = await Mediator.Send(new CreateSiteUserCommand(site, user, publicRegisterModel));
            var siteUserViewModel = Mapper.Map<SiteUserViewModel>(siteUser);
            
            return Ok(siteUserViewModel);
        }

        return Forbid();
    }

    [HttpPost]
    [Route("change-password")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
    {
        var currentUser = await GetCurrentUser();
        var currentSite = await GetCurrentSite();

        if (currentUser == null || currentSite == null)
        {
            return NotFound();
        }

        // System users are never allowed to change passwords.
        if (currentUser.IsInRole(CoreRoles.System))
        {
            return Forbid();
        }

        IdentityResult? identityResult = null;

        // Administrators are always allowed to change passwords.
        if (currentUser.IsInRole(CoreRoles.Administrator))
        {
            identityResult = await Mediator.Send(new ChangePasswordCommand(currentUser, changePasswordModel));
        }

        // Users are allowed to change their provided that they have access to the site.
        if (currentUser.IsInRole(CoreRoles.User))
        {
            var siteUser = currentUser.SiteUsers.FirstOrDefault(su => su.SiteId == currentSite.Id);

            // User has a valid password and has access to the site.
            if (siteUser != null)
            {
                identityResult = await Mediator.Send(new ChangePasswordCommand(siteUser, changePasswordModel));
            }
        }

        if (identityResult == null)
        {
            return BadRequest();
        }

        if (!identityResult.Succeeded)
        {
            return Forbid();
        }

        return Ok();
    }
}