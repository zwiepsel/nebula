using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Nebula.Shared.Clients.State;
using Nebula.Shared.Constants;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Shared.Clients.Security.Authorization.Handlers;

public class SiteRequirementHandler : AuthorizationHandler<SiteRequirement>
{
    private readonly AppState appState;

    public SiteRequirementHandler(AppState appState)
    {
        this.appState = appState;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SiteRequirement requirement)
    {
        var currentSite = appState.Site;

        // Check if user has a site ID in the claim.
        if (!context.User.HasClaim(ClaimTypes.Sid, currentSite.Id.ToString()))
        {
            context.Fail();

            return;
        }

        // Refresh the current user in the app state.
        if (appState.User == null)
        {
            await appState.RefreshCurrentUser();
        }

        // Fail the requirement if the current user is empty after refreshing.
        if (appState.User == null)
        {
            context.Fail();

            return;
        }
        
        // Administrators are always allowed to access a site.
        if (context.User.HasClaim(ClaimTypes.Role, CoreRoles.Administrator))
        {
            context.Succeed(requirement);

            return;
        }

        // Check if the current user has access to the site.
        if (appState.User.SiteUsers.Any(s => s.Site.Id == currentSite.Id))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}