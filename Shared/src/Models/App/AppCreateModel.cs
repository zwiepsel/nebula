namespace Nebula.Shared.Models.App;

public class AppCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public int SiteId { get; set; }
}