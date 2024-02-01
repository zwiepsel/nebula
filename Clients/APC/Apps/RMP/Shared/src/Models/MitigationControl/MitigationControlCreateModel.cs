using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;

public class MitigationControlCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public MitigationControlType? ControlType { get; set; }
    public MitigationControlTrigger? Trigger { get; set; }
}