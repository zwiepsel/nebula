using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.Client;

namespace Nebula.Core.Web.Repositories;

public class ClientRepository : BaseCrudRepository<ClientViewModel, ClientViewModel, ClientCreateModel, ClientUpdateModel>
{
    public ClientRepository(CoreApi api) : base(api, "admin/client")
    {
    }
}