using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class CosoRepository : BaseCrudRepository<CosoViewModel, CosoViewModel, CosoCreateModel, CosoUpdateModel>
{
    public CosoRepository(AppApi api) : base(api, "coso")
    {
    }
}