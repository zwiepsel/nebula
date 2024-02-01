using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Data;

namespace Nebula.Core.Api.Domain.Data;

public interface IDatabaseContext : IBaseDatabaseContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }

    public DbSet<App> Apps { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<SiteUser> SiteUsers { get; set; }
}