using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class FirmRepository : BaseCrudRepository<FirmViewModel, FirmViewModel, FirmCreateModel, FirmUpdateModel>
{
    public FirmRepository(AppApi api) : base(api, "firm")
    {
    }
}