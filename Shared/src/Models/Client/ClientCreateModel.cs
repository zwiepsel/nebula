namespace Nebula.Shared.Models.Client;

public class ClientCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
}