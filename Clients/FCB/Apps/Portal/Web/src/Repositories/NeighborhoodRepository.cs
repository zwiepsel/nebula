using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class NeighborhoodRepository : BaseCrudRepository<NeighborhoodViewModel, NeighborhoodViewModel, NeighborhoodCreateModel,
    NeighborhoodUpdateModel>
{
    public NeighborhoodRepository(AppApi api) : base(api, "neighborhood")
    {
    }
}