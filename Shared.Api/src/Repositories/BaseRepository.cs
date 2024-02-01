using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Shared.Api.Data;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Repositories;

public abstract class BaseRepository<TEntity, TDatabaseContext> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    where TDatabaseContext : IBaseDatabaseContext
{
    protected BaseRepository(TDatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    protected TDatabaseContext DatabaseContext { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.SaveChangesAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DatabaseContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        DatabaseContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity, bool permanent = false)
    {
        DatabaseContext.Delete(entity, permanent);
    }

    public void Restore(TEntity entity)
    {
        if (entity.Deleted)
        {
            entity.Deleted = false;
            entity.DeletedAt = null;
            entity.DeletedById = null;

            DatabaseContext.Set<TEntity>().Update(entity);
        }
        else
        {
            throw new InvalidOperationException(
                $"Cannot restore entity with type '{entity.GetType().Name}' and ID '{entity.Id}'; entity is not marked as deleted");
        }
    }

    public TEntity Refresh(TEntity entity)
    {
        return DatabaseContext.Refresh(entity);
    }

    public async Task<List<TEntity>> FindAll(CancellationToken cancellationToken = default)
    {
        return await FindAll(false, cancellationToken);
    }

    public async Task<List<TEntity>> FindAll(bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        if (includeDeleted)
        {
            return await DatabaseContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        return await DatabaseContext.Set<TEntity>().Where(entity => entity.Deleted == false).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindById(int id, CancellationToken cancellationToken = default)
    {
        return await FindById(id, false, cancellationToken);
    }

    public async Task<TEntity?> FindById(int id, bool includeDeleted, CancellationToken cancellationToken = default)
    {
        if (includeDeleted)
        {
            return await DatabaseContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        return await DatabaseContext.Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id && entity.Deleted == false, cancellationToken);
    }
}