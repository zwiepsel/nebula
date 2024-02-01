using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.ClientType;

public class ClientTypeUpdateModel : UpdateModel
{
    public string Type { get; set; } = null!;
}