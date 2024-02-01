using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Extensions;

public static class DbContextExtensions
{
    private static IEnumerable<EntityEntry> GetEntityMutations<TEntity>(this DbContext dbContext) where TEntity : class, IBaseEntity
    {
        return dbContext.ChangeTracker.Entries().Where(entry =>
            entry.Entity is TEntity && entry.State is EntityState.Added or EntityState.Modified);
    }

    public static void AddAuditData<TEntity>(this DbContext dbContext, int currentUserId) where TEntity : class, IBaseEntity
    {
        foreach (var entity in dbContext.GetEntityMutations<TEntity>())
        {
            if (entity.State == EntityState.Modified)
            {
                var oldValues = entity.Properties.Select(property => property.OriginalValue);
                var newValues = entity.Properties.Select(property => property.CurrentValue);

                if (!new HashSet<object?>(oldValues).SetEquals(new HashSet<object?>(newValues)))
                {
                    ((TEntity)entity.Entity).UpdatedById = currentUserId;
                    ((TEntity)entity.Entity).UpdatedAt = DateTime.UtcNow;
                }
            }

            if (entity.State == EntityState.Added)
            {
                ((TEntity)entity.Entity).CreatedById = currentUserId;
                ((TEntity)entity.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
    }

    public static int GetCurrentUserId(this DbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        var currentUserId = 1;

        if (httpContextAccessor.HttpContext != null)
        {
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (userId != 0)
            {
                currentUserId = userId;
            }
        }

        return currentUserId;
    }

    public static void DoDelete<TEntity>(this DbContext dbContext, TEntity entity, int currentUserId, bool permanent = false) where TEntity : class, IBaseEntity
    {
        if (permanent)
        {
            dbContext.Remove(entity);
        }
        else
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            entity.DeletedById = currentUserId;

            dbContext.Set<TEntity>().Update(entity);
        }
    }

    public static void DoRestore<TEntity>(this DbContext dbContext, TEntity entity) where TEntity : class, IBaseEntity
    {
        if (entity.Deleted)
        {
            entity.Deleted = false;
            entity.DeletedAt = null;
            entity.DeletedById = null;

            dbContext.Set<TEntity>().Update(entity);
        }
        else
        {
            throw new InvalidOperationException(
                $"Cannot restore entity with type '{entity.GetType().Name}' and ID '{entity.Id}'; entity is not marked as deleted");
        }
    }

    public static TEntity DoRefresh<TEntity>(this DbContext dbContext, TEntity entity) where TEntity : class, IBaseEntity
    {
        dbContext.Entry(entity).State = EntityState.Detached;

        return dbContext.Find<TEntity>(entity.Id)!;
    }
}