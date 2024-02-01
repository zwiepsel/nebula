using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Nebula.Shared.Constants;

namespace Nebula.Shared.Security.Authorization.Handlers;

public class SiteAdministratorRequirementHandler : AuthorizationHandler<SiteAdministratorRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SiteAdministratorRequirement requirement)
    {
        if (context.User.HasClaim(ClaimTypes.Role, SiteRoles.SiteAdministrator) || context.User.HasClaim(ClaimTypes.Role, CoreRoles.Administrator))
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }

        context.Fail();

        return Task.CompletedTask;
    }
}