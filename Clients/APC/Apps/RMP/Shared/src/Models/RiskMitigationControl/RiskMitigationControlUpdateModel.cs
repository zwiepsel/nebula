using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;

public class RiskMitigationControlUpdateModel : UpdateModel
{
    public RiskMitigationControlScore Score { get; set; }
}