using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Complex;

public class ComplexViewModel : ViewModel
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string VastCode { get; set; } = null!;
    public virtual NeighborhoodViewModel Neighborhood { get; set; } = null!; 
    public int ConstructionYear { get; set; }
    public int HouseQty { get; set; }
}