using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations;

public class ClientTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.EnableTemporalTable("Clients");

        builder.HasOne(entity => entity.DeletedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.UpdatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(entity => entity.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}