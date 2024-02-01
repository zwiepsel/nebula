using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations;

public class SiteTypeConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.EnableTemporalTable("Sites");

        builder.HasOne(entity => entity.DeletedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.UpdatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(entity => entity.Groups)
            .WithOne(entity => entity.Site)
            .OnDelete(DeleteBehavior.Cascade);
    }
}