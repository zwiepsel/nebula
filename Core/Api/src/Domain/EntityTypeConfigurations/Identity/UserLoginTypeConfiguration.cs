using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;

public class UserLoginTypeConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.EnableTemporalTable("UserLogins");
    }
}