using System.Collections.Generic;

namespace Nebula.Core.Api.Domain.Entities;

public class Permission : Entity
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;

    public int SiteId { get; set; }
    public virtual Site Site { get; set; } = null!;

    public virtual IList<Group> Groups { get; set; } = null!;
}