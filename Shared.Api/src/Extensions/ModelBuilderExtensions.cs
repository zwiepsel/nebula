using Microsoft.EntityFrameworkCore;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Extensions;

public static class ModelBuilderExtensions
{
    public static void EnableTemporalTable<TEntity>(this ModelBuilder modelBuilder, string tableName) where TEntity : class, IBaseEntity
    {
        modelBuilder.Entity<TEntity>().EnableTemporalTable(tableName);
    }
}