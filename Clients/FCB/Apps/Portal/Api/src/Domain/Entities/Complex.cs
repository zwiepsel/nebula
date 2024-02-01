
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Complex : Entity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string VastCode { get; set; } = null!;
    public virtual Neighborhood Neighborhood { get; set; } = null!; 
    public int ConstructionYear { get; set; }
    public int HouseQty { get; set; }
}