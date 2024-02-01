using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Models.Security;

namespace Nebula.Shared.Clients.Data;

public interface IApi
{
    public Task SignInAsync(SignInModel signInModel, CancellationToken cancellationToken);
    public Task SignOutAsync();
    public Task GetAsync(string path, CancellationToken cancellationToken = default);
    public Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default);
    public Task<Stream> GetStreamAsync(string path, CancellationToken cancellationToken = default);
    public Task<T> PostAsync<T>(string path, CancellationToken cancellationToken = default);
    public Task PostAsync(string path, object data, CancellationToken cancellationToken = default);
    public Task<T> PostAsync<T>(string path, object data, CancellationToken cancellationToken = default);
    public Task<T> PostAsync<T>(string path, MultipartFormDataContent data, CancellationToken cancellationToken = default);
    public Task PutAsync(string path, object data, CancellationToken cancellationToken = default);
    public Task<T> PutAsync<T>(string path, object data, CancellationToken cancellationToken = default);
    public Task DeleteAsync(string path, CancellationToken cancellationToken = default);
    public Task<T> DeleteAsync<T>(string path, CancellationToken cancellationToken = default);
}