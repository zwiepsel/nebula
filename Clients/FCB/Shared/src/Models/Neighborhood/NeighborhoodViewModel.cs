using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Neighborhood;

public class NeighborhoodViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public int Valuation { get; set; }
    public int Points { get; set; }
}