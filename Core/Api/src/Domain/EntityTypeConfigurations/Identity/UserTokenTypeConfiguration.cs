using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;

public class UserTokenTypeConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.EnableTemporalTable("UserTokens");
    }
}