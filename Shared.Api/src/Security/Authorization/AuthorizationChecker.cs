using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nebula.Shared.Api.Utilities;
using Nebula.Shared.Models.User;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Shared.Api.Security.Authorization;

public class AuthorizationChecker : IAuthorizationChecker
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthorizationChecker(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> IsInGroup(string groupSystemName)
    {
        try
        {
            var currentUser = await CoreApiHttpClient.Get<UserViewModel>("me/user");

            if (TryGetCurrentSiteId(out var currentSiteId))
            {
                return currentUser.GetSiteUser(currentSiteId).Groups.Any(group => group.SystemName == groupSystemName);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> HasPermission(string permissionSystemName)
    {
        try
        {
            var currentUser = await CoreApiHttpClient.Get<UserViewModel>("me/user");

            if (TryGetCurrentSiteId(out var currentSiteId))
            {
                return currentUser.GetSiteUser(currentSiteId).Permissions.Any(permission => permission.SystemName == permissionSystemName);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    private bool TryGetCurrentSiteId(out int currentSiteId)
    {
        currentSiteId = 0;

        var currentSiteClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid);

        // No site claim in the user claims principal.
        if (currentSiteClaim == null)
        {
            return false;
        }

        if (int.TryParse(currentSiteClaim.Value, out var siteId))
        {
            currentSiteId = siteId;

            return true;
        }

        return false;
    }
}