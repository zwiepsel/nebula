using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Nebula.Shared.Clients.Security;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ApiTokenManager apiTokenManager;

    public ApiAuthenticationStateProvider(ApiTokenManager apiTokenManager)
    {
        this.apiTokenManager = apiTokenManager;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (!await apiTokenManager.IsValid())
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var existingToken = await apiTokenManager.GetToken();
        var authenticatedUser = GetAuthenticatedUser(existingToken!);

        return new AuthenticationState(authenticatedUser);
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var authenticatedUser = GetAuthenticatedUser(token);
        var authenticationState = Task.FromResult(new AuthenticationState(authenticatedUser));

        NotifyAuthenticationStateChanged(authenticationState);
    }

    public void MarkUserAsSignedOutOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authenticationState = Task.FromResult(new AuthenticationState(anonymousUser));

        NotifyAuthenticationStateChanged(authenticationState);
    }

    private static IEnumerable<Claim> ParseClaimsFromToken(string token)
    {
        var claims = new List<Claim>();
        var payload = token.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs != null)
        {
            keyValuePairs.TryGetValue(ClaimTypes.Role, out var roles);

            if (roles != null)
            {
                if (roles.ToString()!.Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString()!);

                    if (parsedRoles != null) claims.AddRange(parsedRoles.Select(parsedRole => new Claim(ClaimTypes.Role, parsedRole)));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()!));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
        }

        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    private static ClaimsPrincipal GetAuthenticatedUser(string token)
    {
        return new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromToken(token), "apiAuthentication"));
    }
}