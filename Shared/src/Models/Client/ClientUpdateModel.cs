namespace Nebula.Shared.Models.Client;

public class ClientUpdateModel : UpdateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
}