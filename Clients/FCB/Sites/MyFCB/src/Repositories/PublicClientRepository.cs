using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicClientRepository: BaseCrudRepository<ClientViewModel, ClientViewModel, ClientCreateModel, ClientUpdateModel>
{
    public PublicClientRepository(AppApi api) : base(api, "client")
    {
    }

}