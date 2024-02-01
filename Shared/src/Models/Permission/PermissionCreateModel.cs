namespace Nebula.Shared.Models.Permission;

public class PermissionCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
}