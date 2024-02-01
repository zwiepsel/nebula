using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Nebula.Shared.Api.Utilities;
using Nebula.Shared.Exceptions;
using Nebula.Shared.Models.User;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Shared.Api.Security.Authorization.Handlers;

public class SiteRequirementHandler : AuthorizationHandler<SiteRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SiteRequirement requirement)
    {
        var currentSiteClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid);

        // No site claim in the user claims principal.
        if (currentSiteClaim == null)
        {
            Fail(context);

            return;
        }

        try
        {
            var currentUser = await CoreApiHttpClient.Get<UserViewModel>("me/user");

            if (int.TryParse(currentSiteClaim.Value, out var currentSiteId))
            {
                if (currentUser.SiteUsers.Any(s => s.Site.Id == currentSiteId))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    Fail(context);
                }
            }
            else
            {
                Fail(context);
            }
        }
        catch (HttpException)
        {
            Fail(context);
        }
    }

    private void Fail(AuthorizationHandlerContext context)
    {
        context.Fail();

        if (context.Resource is HttpContext httpContext)
        {
            var response = httpContext.Response;

            response.OnStarting(() =>
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            });
        }
    }
}