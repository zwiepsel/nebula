using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class ProcessRepository : BaseCrudRepository<ProcessViewModel, ProcessViewModel, ProcessCreateModel, ProcessUpdateModel>
{
    public ProcessRepository(AppApi api) : base(api, "process")
    {
    }
}