using System;
using System.Collections.Generic;
using System.Reflection;
using Nebula.Shared.Models.App;
using Nebula.Shared.Models.Client;

namespace Nebula.Shared.Models.Site;

public class SiteViewModel : ViewModel
{
    public bool Core { get; set; }
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int? Port { get; set; }
    public bool AllowPublicRegistration { get; set; }

    public ClientViewModel Client { get; set; } = null!;
    public IEnumerable<AppViewModel> Apps { get; set; } = null!;

    public Uri Uri => Port == null ? new Uri($"https://{Host}") : new Uri($"https://{Host}:{Port}");

    public Type GetSiteType()
    {
        return Type.GetType($"{SystemName}.Site, {SystemName}")!;
    }

    public Assembly GetSiteAssembly()
    {
        return GetSiteType().Assembly;
    }

    public Type GetStartupType()
    {
        return Type.GetType($"{SystemName}.Startup, {SystemName}")!;
    }
}