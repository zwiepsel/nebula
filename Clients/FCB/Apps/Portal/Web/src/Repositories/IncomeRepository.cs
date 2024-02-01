using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class IncomeRepository : BaseCrudRepository<IncomeViewModel, IncomeViewModel, IncomeCreateModel, IncomeUpdateModel>
{
    public IncomeRepository(AppApi api) : base(api, "income")
    {
    }
}