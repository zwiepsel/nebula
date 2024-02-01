using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.EnableTemporalTable("Permissions");

        builder.HasOne(entity => entity.DeletedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.UpdatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(entity => entity.Site)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(entity => entity.Groups)
            .WithMany(entity => entity.Permissions)
            .UsingEntity(entity => entity.ToTable("GroupPermissions"));
    }
}