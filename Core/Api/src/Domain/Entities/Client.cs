using System.Collections.Generic;

namespace Nebula.Core.Api.Domain.Entities;

public class Client : Entity
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;

    public virtual IList<Site> Sites { get; set; } = null!;
}