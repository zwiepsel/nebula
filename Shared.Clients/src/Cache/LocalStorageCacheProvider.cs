using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Nebula.Shared.Clients.Cache;

public class LocalStorageCacheProvider : ICache
{
    private readonly ILocalStorageService localStorageService;

    public LocalStorageCacheProvider(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public async Task Clear()
    {
        await localStorageService.ClearAsync();
    }

    public async Task<T> GetItem<T>(string key)
    {
        return await localStorageService.GetItemAsync<T>(key);
    }

    public async Task SetItem<T>(string key, T data)
    {
        await localStorageService.SetItemAsync(key, data);
    }

    public async Task RemoveItem(string key)
    {
        await localStorageService.RemoveItemAsync(key);
    }

    public async Task<bool> ContainsKey(string key)
    {
        return await localStorageService.ContainKeyAsync(key);
    }
}