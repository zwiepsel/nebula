using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;

public class RiskPossibleOptimizationViewModel : ViewModel
{
    public int RiskId { get; set; }
    public RiskMitigationControlScore Score { get; set; }
    public MitigationControlViewModel MitigationControl { get; set; } = null!;
}