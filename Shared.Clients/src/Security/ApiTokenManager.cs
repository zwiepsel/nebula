using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Nebula.Shared.Clients.Security;

public class ApiTokenManager
{
    private const string TokenName = "authentication_token";
    private const string TokenExpirationName = "authentication_token_expiration";

    private readonly ILocalStorageService localStorage;

    public ApiTokenManager(ILocalStorageService localStorage)
    {
        this.localStorage = localStorage;
    }

    public async Task<bool> IsValid()
    {
        var existingToken = await GetToken();
        var existingTokenExpirationDateTime = await GetTokenExpiration();

        if (existingToken == null || DateTime.UtcNow >= existingTokenExpirationDateTime)
        {
            return false;
        }

        return true;
    }

    public async Task<string?> GetToken()
    {
        return await localStorage.GetItemAsync<string?>(TokenName);
    }

    public async Task SetToken(string token)
    {
        await localStorage.SetItemAsync(TokenName, token);
    }

    public async Task RemoveToken()
    {
        await localStorage.RemoveItemAsync(TokenName);
    }

    public async Task<DateTime?> GetTokenExpiration()
    {
        return await localStorage.GetItemAsync<DateTime?>(TokenExpirationName);
    }

    public async Task SetTokenExpiration(DateTime tokenExpiration)
    {
        await localStorage.SetItemAsync(TokenExpirationName, tokenExpiration);
    }

    public async Task RemoveTokenExpiration()
    {
        await localStorage.RemoveItemAsync(TokenExpirationName);
    }
}