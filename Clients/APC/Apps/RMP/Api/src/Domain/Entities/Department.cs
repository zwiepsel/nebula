using System.Collections.Generic;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class Department : Entity
{
    public string Name { get; set; } = null!;

    public virtual IList<Risk> Risks { get; set; } = null!;
}