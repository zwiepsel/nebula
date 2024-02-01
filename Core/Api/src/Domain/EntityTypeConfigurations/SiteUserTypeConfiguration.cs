using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations;

public class SiteUserTypeConfiguration : IEntityTypeConfiguration<SiteUser>
{
    public void Configure(EntityTypeBuilder<SiteUser> builder)
    {
        builder.EnableTemporalTable("SiteUsers");

        builder.HasOne(entity => entity.DeletedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.UpdatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(siteUser => siteUser.User)
            .WithMany(user => user.SiteUsers)
            .HasForeignKey(siteUser => siteUser.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(siteUser => siteUser.Site)
            .WithMany(site => site.SiteUsers)
            .HasForeignKey(siteUser => siteUser.SiteId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(entity => entity.Groups)
            .WithMany(entity => entity.SiteUsers)
            .UsingEntity(entity => entity.ToTable("SiteUserGroups"));
    }
}