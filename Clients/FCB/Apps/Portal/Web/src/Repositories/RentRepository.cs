using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Rent;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class RentRepository : BaseCrudRepository<RentViewModel, RentViewModel, RentCreateModel, RentUpdateModel>
{
    public RentRepository(AppApi api) : base(api, "rent")
    {
    }
}