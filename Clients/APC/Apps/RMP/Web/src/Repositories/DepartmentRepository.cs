using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class DepartmentRepository : BaseCrudRepository<DepartmentViewModel, DepartmentViewModel, DepartmentCreateModel,
    DepartmentUpdateModel>
{
    public DepartmentRepository(AppApi api) : base(api, "department")
    {
    }
}