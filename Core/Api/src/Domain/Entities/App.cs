namespace Nebula.Core.Api.Domain.Entities;

public class App : Entity
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string Icon { get; set; } = null!;

    public int SiteId { get; set; }
    public virtual Site Site { get; set; } = null!;
}