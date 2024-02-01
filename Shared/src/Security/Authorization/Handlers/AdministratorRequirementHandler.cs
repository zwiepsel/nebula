using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Nebula.Shared.Constants;

namespace Nebula.Shared.Security.Authorization.Handlers;

public class AdministratorRequirementHandler : AuthorizationHandler<AdministratorRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdministratorRequirement requirement)
    {
        if (context.User.HasClaim(ClaimTypes.Role, CoreRoles.Administrator))
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }

        context.Fail();

        return Task.CompletedTask;
    }
}