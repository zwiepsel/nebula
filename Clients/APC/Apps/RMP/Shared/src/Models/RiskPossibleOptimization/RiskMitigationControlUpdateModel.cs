using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;

public class RiskPossibleOptimizationUpdateModel : UpdateModel
{
    public RiskMitigationControlScore Score { get; set; }
}