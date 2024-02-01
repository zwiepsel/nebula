using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.Complex;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class ComplexRepository : BaseCrudRepository<ComplexViewModel, ComplexViewModel, ComplexCreateModel, ComplexUpdateModel>
{
    public ComplexRepository(AppApi api) : base(api, "complex")
    {
    }
}