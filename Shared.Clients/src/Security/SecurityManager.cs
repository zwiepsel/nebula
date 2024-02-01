using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.State;
using Nebula.Shared.Models.Security;
using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Shared.Clients.Security;

public class SecurityManager
{
    private readonly CoreApi api;
    private readonly AppState appState;
    private readonly ApiTokenManager apiTokenManager;
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly IAuthorizationService authorizationService;

    public SecurityManager(CoreApi api,
        AppState appState,
        ApiTokenManager apiTokenManager,
        IAuthorizationService authorizationService,
        AuthenticationStateProvider authenticationStateProvider)
    {
        this.api = api;
        this.appState = appState;
        this.apiTokenManager = apiTokenManager;
        this.authorizationService = authorizationService;
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task SignInAsync(SignInModel signInModel, CancellationToken cancellationToken = default)
    {
        await api.SignInAsync(signInModel, cancellationToken);
        await appState.RefreshCurrentUser(cancellationToken);
    }

    public async Task SignOutAsync()
    {
        await api.SignOutAsync();
        appState.RemoveCurrentUser();
    }

    public async Task<bool> IsSignedIn()
    {
        var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var authorizationResult = await authorizationService.AuthorizeAsync(authenticationState.User, SiteRequirement.Name);

        if (await apiTokenManager.IsValid() && authorizationResult.Succeeded)
        {
            return true;
        }

        return false;
    }

    public async Task ChangePasswordAsync(ChangePasswordModel changePasswordModel, CancellationToken cancellationToken = default)
    {
        await api.PostAsync("security/change-password", changePasswordModel, cancellationToken);
    }
    
    public async Task<SiteUserViewModel> RegisterPublic(PublicRegisterModel publicRegisterModel, CancellationToken cancellationToken = default)
    {
        return await api.PostAsync<SiteUserViewModel>("security/register-public", publicRegisterModel, cancellationToken);
    }
}