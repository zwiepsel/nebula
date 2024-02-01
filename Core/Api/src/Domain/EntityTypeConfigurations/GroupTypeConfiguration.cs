using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations;

public class GroupTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.EnableTemporalTable("Groups");

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
            .WithMany(entity => entity.Groups)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(entity => entity.Permissions)
            .WithMany(entity => entity.Groups)
            .UsingEntity(entity => entity.ToTable("GroupPermissions"));
        builder.HasMany(entity => entity.SiteUsers)
            .WithMany(entity => entity.Groups)
            .UsingEntity(entity => entity.ToTable("SiteUserGroups"));
    }
}