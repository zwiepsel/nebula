using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.App;

namespace Nebula.Core.Web.Repositories;

public class AppRepository : BaseCrudRepository<AppViewModel, AppViewModel, AppCreateModel, AppUpdateModel>
{
    public AppRepository(CoreApi api) : base(api, "admin/app")
    {
    }
}