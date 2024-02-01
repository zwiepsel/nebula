using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;

public class RoleClaimTypeConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.EnableTemporalTable("RoleClaims");
    }
}