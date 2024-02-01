using System;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Entities;

namespace Nebula.Core.Api.Domain.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedClients(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                Id = 1,
                Name = "Nebula",
                SystemName = "Nebula.Core",
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Client
            {
                Id = 100,
                Name = "APC",
                SystemName = "Nebula.Clients.APC",
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Client
            {
                Id = 101,
                Name = "FCB",
                SystemName = "Nebula.Clients.FCB",
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Client
            {
                Id = 102,
                Name = "ETB",
                SystemName = "Nebula.Clients.ETB",
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            }
        );
    }

    public static void SeedSites(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Site>().HasData(
            new Site
            {
                Id = 1,
                Core = true,
                Name = "Nebula",
                SystemName = "Nebula.Core.Web",
                Host = "core.nebula.local",
                Port = 5000,
                ClientId = 1,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Site
            {
                Id = 100,
                Name = "APC",
                SystemName = "Nebula.Clients.APC.Sites.APC",
                Host = "apc.nebula.local",
                Port = 5000,
                ClientId = 100,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Site
            {
                Id = 101,
                Name = "FCB",
                SystemName = "Nebula.Clients.FCB.Sites.FCB",
                Host = "fcb.nebula.local",
                Port = 5000,
                ClientId = 101,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Site
            {
                Id = 102,
                Name = "ETB",
                SystemName = "Nebula.Clients.ETB.Sites.ETB",
                Host = "etb.nebula.local",
                Port = 5000,
                ClientId = 102,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new Site
            {
                Id = 103,
                Name = "Mijn FCB",
                SystemName = "Nebula.Clients.FCB.Sites.MyFCB",
                Host = "my-fcb.nebula.local",
                Port = 5000,
                AllowPublicRegistration = true,
                ClientId = 101,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            }
        );
    }

    public static void SeedApps(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>().HasData(
            new App
            {
                Id = 100,
                Name = "RMP",
                SystemName = "Nebula.Clients.APC.Apps.RMP.Web",
                DisplayName = "Risks",
                Path = "risk",
                Icon = "exclamation-triangle",
                SiteId = 100,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new App
            {
                Id = 101,
                Name = "Portal",
                SystemName = "Nebula.Clients.FCB.Apps.Portal.Web",
                DisplayName = "Portal",
                Path = "",
                Icon = "browser",
                SiteId = 101,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            },
            new App
            {
                Id = 102,
                Name = "Portal",
                SystemName = "Nebula.Clients.ETB.Apps.Portal.Web",
                DisplayName = "Portal",
                Path = "",
                Icon = "browser",
                SiteId = 102,
                CreatedById = 1,
                CreatedAt = new DateTime(1970, 01, 01)
            }
        );
    }
}