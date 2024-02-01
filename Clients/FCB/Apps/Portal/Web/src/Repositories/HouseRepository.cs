using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class HouseRepository : BaseCrudRepository<HouseViewModel, HouseIndexViewModel, HouseCreateModel, HouseUpdateModel>
{
    public HouseRepository(AppApi api) : base(api, "house")
    {
    }
}