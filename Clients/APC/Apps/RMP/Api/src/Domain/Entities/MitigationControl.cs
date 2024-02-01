using System.Collections.Generic;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class MitigationControl : Entity
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public MitigationControlType ControlType { get; set; }
    public MitigationControlTrigger Trigger { get; set; }
    public virtual IList<File> Files { get; set; } = null!;
}