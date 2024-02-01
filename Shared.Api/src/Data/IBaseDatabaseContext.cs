using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Data;

public interface IBaseDatabaseContext : IDisposable, IAsyncDisposable
{
    public void Migrate();
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public void Delete<TEntity>(TEntity entity, bool permanent = false) where TEntity : class, IBaseEntity;
    public void Restore<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;
    public TEntity Refresh<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;
}