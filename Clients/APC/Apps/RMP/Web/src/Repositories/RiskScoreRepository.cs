using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Web.Repositories;

public class RiskScoreRepository : BaseCrudRepository<RiskScoreViewModel,
    RiskScoreViewModel,
    RiskScoreCreateModel,
    RiskScoreUpdateModel>
{
    public RiskScoreRepository(AppApi api) : base(api, "risk-score")
    {
    }
}