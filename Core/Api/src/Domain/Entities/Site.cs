using System.Collections.Generic;

namespace Nebula.Core.Api.Domain.Entities;

public class Site : Entity
{
    public bool Core { get; set; }
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int? Port { get; set; }
    public bool AllowPublicRegistration { get; set; }

    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

    public virtual IList<Group> Groups { get; set; } = null!;
    public virtual IList<SiteUser> SiteUsers { get; set; } = null!;
    public virtual IList<App> Apps { get; set; } = null!;
}