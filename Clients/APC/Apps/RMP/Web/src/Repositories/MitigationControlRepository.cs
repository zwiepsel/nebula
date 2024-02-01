using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class MitigationControlRepository : BaseCrudRepository<MitigationControlViewModel,
    MitigationControlViewModel,
    MitigationControlCreateModel,
    MitigationControlUpdateModel>
{
    public MitigationControlRepository(AppApi api) : base(api, "mitigation-control")
    {
    }

    public async Task<MitigationControlViewModel> CreateMitigationControlFile(int id, int fileId,
        CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<MitigationControlViewModel>($"mitigation-control/{id}/file/{fileId}", cancellationToken);
    }
}