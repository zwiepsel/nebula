using System.Linq;
using System.Threading.Tasks;
using Nebula.Shared.Clients.State;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Shared.Clients.Security.Authorization;

public class AuthorizationChecker : IAuthorizationChecker
{
    private readonly AppState appState;

    public AuthorizationChecker(AppState appState)
    {
        this.appState = appState;
    }

    public async Task<bool> IsInGroup(string groupSystemName)
    {
        if (appState.User != null)
        {
            var currentSiteId = appState.Site.Id;

            return await Task.FromResult(appState.User.GetSiteUser(currentSiteId).Groups.Any(group => group.SystemName == groupSystemName));
        }

        return false;
    }

    public async Task<bool> HasPermission(string permissionSystemName)
    {
        if (appState.User != null)
        {
            var currentSiteId = appState.Site.Id;

            return await Task.FromResult(appState.User.GetSiteUser(currentSiteId).Permissions.Any(permission => permission.SystemName == permissionSystemName));
        }

        return false;
    }
}