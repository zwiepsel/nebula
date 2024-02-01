using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class PersonRepository : BaseCrudRepository<PersonViewModel, PersonViewModel, PersonCreateModel, PersonUpdateModel>
{
    public PersonRepository(AppApi api) : base(api, "person")
    {
    }

    public async Task<IList<PersonIndexViewModel>> GetAllApplicants(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<PersonIndexViewModel>>($"{EntityBaseUri}/applicant", cancellationToken);
    }

    public async Task<IList<PersonIndexViewModel>> GetAllTenants(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<PersonIndexViewModel>>($"{EntityBaseUri}/tenant", cancellationToken);
    }
    
}