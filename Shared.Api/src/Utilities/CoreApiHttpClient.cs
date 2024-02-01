using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Utilities;

namespace Nebula.Shared.Api.Utilities;

public static class CoreApiHttpClient
{
    private static HttpClient httpClient = null!;

    public static void Create(string baseAddress, string accessToken)
    {
        httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri(baseAddress);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public static async Task<HttpResponseMessage> GetResponse(string path, CancellationToken cancellationToken = default)
    {
        if (httpClient == null)
        {
            throw new InvalidOperationException($"{nameof(CoreApiHttpClient)} not initialized.");
        }

        return await httpClient.GetAsync(path, cancellationToken);
    }

    public static async Task<T> Get<T>(string path, CancellationToken cancellationToken = default)
    {
        var response = await GetResponse(path, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<T>(content, cancellationToken);
    }
}