using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Shared.Api.Data;

public abstract class BaseDatabaseContext<TDatabaseContext> : DbContext, IBaseDatabaseContext where TDatabaseContext : DbContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    protected BaseDatabaseContext(DbContextOptions<TDatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public override int SaveChanges()
    {
        this.AddAuditData<IBaseEntity>(this.GetCurrentUserId(httpContextAccessor));

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.AddAuditData<IBaseEntity>(this.GetCurrentUserId(httpContextAccessor));

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
}