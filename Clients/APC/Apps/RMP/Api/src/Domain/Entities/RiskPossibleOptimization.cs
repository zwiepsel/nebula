using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class RiskPossibleOptimization : Entity
{
    public RiskMitigationControlScore Score { get; set; }

    public int RiskId { get; set; }
    public virtual Risk Risk { get; set; } = null!;

    public int MitigationControlId { get; set; }
    public virtual MitigationControl MitigationControl { get; set; } = null!;
}