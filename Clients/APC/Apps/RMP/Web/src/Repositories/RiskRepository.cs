using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class RiskRepository : BaseCrudRepository<RiskViewModel, RiskIndexViewModel, RiskCreateModel, RiskUpdateModel>
{
    public RiskRepository(AppApi api) : base(api, "risk")
    {
    }

    public async Task<RiskViewModel> CreateRiskFile(int id, int fileId, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<RiskViewModel>($"risk/{id}/file/{fileId}", cancellationToken);
    }

    public async Task<RiskViewModel> CreateRiskDepartment(int id, int departmentId, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<RiskViewModel>($"risk/{id}/department/{departmentId}", cancellationToken);
    }

    public async Task<RiskViewModel> DeleteRiskDepartment(int id, int departmentId, CancellationToken cancellationToken = default)
    {
        return await Api.DeleteAsync<RiskViewModel>($"risk/{id}/department/{departmentId}", cancellationToken);
    }

    public async Task<RiskMitigationControlViewModel> CreateRiskMitigationControl(int id, int mitigationControlId,
        MitigationControlLinkModel model,
        CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<RiskMitigationControlViewModel>($"risk/{id}/mitigation-control/{mitigationControlId}", model,
            cancellationToken);
    }

    public async Task<RiskMitigationControlViewModel> UpdateRiskMitigationControl(int id, RiskMitigationControlUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<RiskMitigationControlViewModel>($"risk-mitigation-control/{id}", model,
            cancellationToken);
    }

    public async Task<RiskViewModel> DeleteRiskMitigationControl(int id, int mitigationControlId,
        CancellationToken cancellationToken = default)
    {
        return await Api.DeleteAsync<RiskViewModel>($"risk/{id}/mitigation-control/{mitigationControlId}", cancellationToken);
    }

    public async Task<RiskPossibleOptimizationViewModel> CreateRiskPossibleOptimization(int id, int mitigationControlId,
        MitigationControlLinkModel model,
        CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<RiskPossibleOptimizationViewModel>($"risk/{id}/possible-optimization/{mitigationControlId}", model,
            cancellationToken);
    }

    public async Task<RiskPossibleOptimizationViewModel> UpdateRiskPossibleOptimization(int id,
        RiskPossibleOptimizationUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<RiskPossibleOptimizationViewModel>($"risk-possible-optimization/{id}", model,
            cancellationToken);
    }

    public async Task<RiskViewModel> DeleteRiskPossibleOptimization(int id, int mitigationControlId,
        CancellationToken cancellationToken = default)
    {
        return await Api.DeleteAsync<RiskViewModel>($"risk/{id}/possible-optimization/{mitigationControlId}", cancellationToken);
    }
}