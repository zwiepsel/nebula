using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using Nebula.Shared.Clients.Extensions;
using Nebula.Shared.Clients.Security;
using Nebula.Shared.Clients.Settings;
using Nebula.Shared.Exceptions;
using Nebula.Shared.Models.Security;
using Nebula.Shared.Utilities;

namespace Nebula.Shared.Clients.Data;

public abstract class BaseApi : IApi
{
    private readonly ApiTokenManager apiTokenManager;
    private readonly AuthenticationStateProvider authenticationStateProvider;
    public readonly bool CoreApi;

    private readonly HttpClient httpClient;
    private readonly ILogger<BaseApi> logger;
    private readonly NavigationManager navigationManager;
    private readonly IWebAssemblyHostEnvironment webAssemblyHostEnvironment;

    public BaseApi(ILogger<BaseApi> logger,
        ApiTokenManager apiTokenManager,
        AuthenticationStateProvider authenticationStateProvider,
        NavigationManager navigationManager,
        IWebAssemblyHostEnvironment webAssemblyHostEnvironment,
        CoreApiSettings coreApiSettings,
        IApiSettings appApiSettings,
        bool coreApi)
    {
        httpClient = new HttpClient();

        AppUri = appApiSettings.Uri;
        CoreUri = coreApiSettings.Uri;
        CoreApi = coreApi;

        this.logger = logger;
        this.apiTokenManager = apiTokenManager;
        this.authenticationStateProvider = authenticationStateProvider;
        this.navigationManager = navigationManager;
        this.webAssemblyHostEnvironment = webAssemblyHostEnvironment;
    }

    public string AppUri { get; }
    private string CoreUri { get; }

    public async Task SignInAsync(SignInModel signInModel, CancellationToken cancellationToken = default)
    {
        var response = await PostAsyncCore("security/sign-in", signInModel, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<ApiTokenModel>(content);

        await apiTokenManager.SetToken(result.Token);
        await apiTokenManager.SetTokenExpiration(result.Expiration);

        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
    }

    public async Task SignOutAsync()
    {
        await apiTokenManager.RemoveToken();
        await apiTokenManager.RemoveTokenExpiration();

        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsSignedOutOut();
        httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task GetAsync(string path, CancellationToken cancellationToken = default)
    {
        await GetAsyncCore(path, cancellationToken);
    }

    public async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        var response = await GetAsyncCore(path, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    public async Task<Stream> GetStreamAsync(string path, CancellationToken cancellationToken = default)
    {
        var response = await GetAsyncCore(path, cancellationToken);

        return await response.Content.ReadAsStreamAsync(cancellationToken);
    }

    public async Task<T> PostAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        var response = await PostAsyncCore(path, new { }, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    public async Task PostAsync(string path, object data, CancellationToken cancellationToken = default)
    {
        await PostAsyncCore(path, data, cancellationToken);
    }

    public async Task<T> PostAsync<T>(string path, object data, CancellationToken cancellationToken = default)
    {
        var response = await PostAsyncCore(path, data, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    public async Task<T> PostAsync<T>(string path, MultipartFormDataContent data, CancellationToken cancellationToken = default)
    {
        var response = await PostAsyncCore(path, data, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    public async Task PutAsync(string path, object data, CancellationToken cancellationToken = default)
    {
        await PutAsyncCore(path, data, cancellationToken);
    }

    public async Task<T> PutAsync<T>(string path, object data, CancellationToken cancellationToken = default)
    {
        var response = await PutAsyncCore(path, data, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    public async Task DeleteAsync(string path, CancellationToken cancellationToken = default)
    {
        await DeleteAsyncCore(path, cancellationToken);
    }

    public async Task<T> DeleteAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        var response = await DeleteAsyncCore(path, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }

    private async Task HandleError(HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await apiTokenManager.RemoveToken();
            await apiTokenManager.RemoveTokenExpiration();

            navigationManager.NavigateTo("/security/sign-in");

            await Task.Delay(int.MaxValue, cancellationToken);
        }

        if (response.StatusCode == HttpStatusCode.UpgradeRequired)
        {
            navigationManager.NavigateTo(navigationManager.Uri, true);

            await Task.Delay(int.MaxValue, cancellationToken);
        }

        var errorMessage =
            $"HTTP {response.RequestMessage?.Method.Method} request unsuccessful: [{(int)response.StatusCode}] {response.ReasonPhrase}";

        if (webAssemblyHostEnvironment.IsDevelopmentEnvironment() || webAssemblyHostEnvironment.IsTestEnvironment())
        {
            var requestUri = response.RequestMessage?.RequestUri?.ToString();
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

            logger.LogError("{ErrorMessage}. {RequestUri} => Response content: {ErrorContent}", errorMessage, requestUri, errorContent);
        }

        throw HttpExceptionFactory.Create(response.StatusCode, errorMessage);
    }

    private string GetRequestUri(string path)
    {
        var uri = CoreApi ? CoreUri : AppUri;

        if (!uri.EndsWith('/')) uri += '/';

        return uri + path;
    }

    private async Task SetTokenData()
    {
        var existingToken = await apiTokenManager.GetToken();

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", existingToken);
    }

    private async Task<HttpResponseMessage> GetAsyncCore(string path, CancellationToken cancellationToken = default)
    {
        await SetTokenData();
        var response = await httpClient.GetAsync(GetRequestUri(path), cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return response;
    }

    private async Task<HttpResponseMessage> PostAsyncCore(string path, object content, CancellationToken cancellationToken = default)
    {
        var postContent = JsonSerializer.Serialize(content);
        var postData = new StringContent(postContent, Encoding.UTF8, "application/json");

        await SetTokenData();
        var response = await httpClient.PostAsync(GetRequestUri(path), postData, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return response;
    }

    private async Task<HttpResponseMessage> PostAsyncCore(string path, MultipartFormDataContent content,
        CancellationToken cancellationToken = default)
    {
        await SetTokenData();
        var response = await httpClient.PostAsync(GetRequestUri(path), content, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return response;
    }

    private async Task<HttpResponseMessage> PutAsyncCore(string path, object content, CancellationToken cancellationToken = default)
    {
        var putContent = JsonSerializer.Serialize(content);
        var putData = new StringContent(putContent, Encoding.UTF8, "application/json");

        await SetTokenData();
        var response = await httpClient.PutAsync(GetRequestUri(path), putData, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return response;
    }

    private async Task<HttpResponseMessage> DeleteAsyncCore(string path, CancellationToken cancellationToken = default)
    {
        await SetTokenData();
        var response = await httpClient.DeleteAsync(GetRequestUri(path), cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return response;
    }
}