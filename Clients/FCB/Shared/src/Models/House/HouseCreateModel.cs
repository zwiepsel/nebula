using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.House;

public class HouseCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
}