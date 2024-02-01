using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Rent;

public class RentCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
}