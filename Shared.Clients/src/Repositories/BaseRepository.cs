using Nebula.Shared.Clients.Data;

namespace Nebula.Shared.Clients.Repositories;

public abstract class BaseRepository
{
    protected IApi Api;

    protected BaseRepository(IApi api)
    {
        Api = api;
    }
}