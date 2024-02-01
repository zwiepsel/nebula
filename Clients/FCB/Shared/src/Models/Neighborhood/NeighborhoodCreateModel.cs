using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Neighborhood;

public class NeighborhoodCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
}