using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

public class RiskCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public int? ProcessId { get; set; }
}