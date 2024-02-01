using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.ClientType;

public class ClientTypeCreateModel : CreateModel
{
    public string Type { get; set; } = null!;
}