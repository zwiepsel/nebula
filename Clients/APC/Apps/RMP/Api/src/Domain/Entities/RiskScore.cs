using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class RiskScore : Entity
{
    public string Frequency { get; set; } = null!;
    public string Impact { get; set; } = null!;
    public RiskScoreType Type { get; set; }
    public int Score { get; set; }
}