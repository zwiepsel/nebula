using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class ClientRepository: BaseCrudRepository<ClientViewModel, ClientViewModel, ClientCreateModel, ClientUpdateModel>
{
    public ClientRepository(AppApi api) : base(api, "client")
    {
    }
    
    public async Task<IList<ClientIndexViewModel>> GetAllApplicants(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<ClientIndexViewModel>>($"{EntityBaseUri}/applicant", cancellationToken);
    }

    public async Task<IList<ClientIndexViewModel>> GetAllTenants(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<ClientIndexViewModel>>($"{EntityBaseUri}/tenant", cancellationToken);
    }
}