using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Neighborhood;

public class NeighborhoodUpdateModel : UpdateModel
{
    public string Name { get; set; } = null!;
}