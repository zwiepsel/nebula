using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;

public class UserClaimTypeConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.EnableTemporalTable("UserClaims");
    }
}