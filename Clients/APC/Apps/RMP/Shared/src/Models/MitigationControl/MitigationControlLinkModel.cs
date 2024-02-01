using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;

public class MitigationControlLinkModel : CreateModel
{
    public MitigationControlViewModel MitigationControl { get; set; } = null!;
    public RiskMitigationControlScore? Score { get; set; }
}