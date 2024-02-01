using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Core.Api.Domain.EntityTypeConfigurations;
using Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;
using Nebula.Core.Api.Domain.Extensions;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Infrastructure.Data;

public class DatabaseContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDatabaseContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public override DbSet<User> Users { get; set; } = null!;
    public override DbSet<UserRole> UserRoles { get; set; } = null!;
    public override DbSet<UserLogin> UserLogins { get; set; } = null!;
    public override DbSet<UserClaim> UserClaims { get; set; } = null!;
    public override DbSet<UserToken> UserTokens { get; set; } = null!;
    public override DbSet<Role> Roles { get; set; } = null!;
    public override DbSet<RoleClaim> RoleClaims { get; set; } = null!;

    public DbSet<App> Apps { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<Site> Sites { get; set; } = null!;
    public DbSet<SiteUser> SiteUsers { get; set; } = null!;

    public override int SaveChanges()
    {
        this.AddAuditData<IEntity>(this.GetCurrentUserId(httpContextAccessor));

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.AddAuditData<IEntity>(this.GetCurrentUserId(httpContextAccessor));

        return await base.SaveChangesAsync(cancellationToken);
    }

    public void Delete<TEntity>(TEntity entity, bool permanent = false) where TEntity : class, IBaseEntity
    {
        this.DoDelete(entity, this.GetCurrentUserId(httpContextAccessor), permanent);
    }

    public void Restore<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        this.DoRestore(entity);
    }

    public TEntity Refresh<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        return this.DoRefresh(entity);
    }

    public void Migrate()
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity type configurations.
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserClaimTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserTokenTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleClaimTypeConfiguration());

        // Entity type configurations.
        modelBuilder.ApplyConfiguration(new AppTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GroupTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SiteTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SiteUserTypeConfiguration());

        // Data seeds.
        modelBuilder.SeedClients();
        modelBuilder.SeedSites();
        modelBuilder.SeedApps();
    }
}