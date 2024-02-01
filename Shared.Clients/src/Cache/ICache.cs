using System.Threading.Tasks;

namespace Nebula.Shared.Clients.Cache;

public interface ICache
{
    public Task Clear();
    public Task<T> GetItem<T>(string key);
    public Task SetItem<T>(string key, T data);
    public Task RemoveItem(string key);
    public Task<bool> ContainsKey(string key);
}