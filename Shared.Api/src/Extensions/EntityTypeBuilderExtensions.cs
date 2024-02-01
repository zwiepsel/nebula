using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nebula.Shared.Api.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static void EnableTemporalTable(this EntityTypeBuilder entityTypeBuilder, string tableName)
    {
        entityTypeBuilder.ToTable(tableName,
            tableBuilder =>
                tableBuilder.IsTemporal(temporalTableBuilder =>
                    temporalTableBuilder.UseHistoryTable($"{tableName}History")));
    }
}