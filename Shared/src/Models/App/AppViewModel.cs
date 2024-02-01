using System;
using Nebula.Shared.Models.Site;

namespace Nebula.Shared.Models.App;

public class AppViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public SiteViewModel Site { get; set; } = null!;

    public string NavigationPath => $"/{Path}";

    public Type GetAppType()
    {
        return Type.GetType($"{SystemName}.App, {SystemName}")!;
    }

    public Type GetStartupType()
    {
        return Type.GetType($"{SystemName}.Startup, {SystemName}")!;
    }
}