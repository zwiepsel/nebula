namespace Nebula.Shared.Models.Group;

public class GroupCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
}