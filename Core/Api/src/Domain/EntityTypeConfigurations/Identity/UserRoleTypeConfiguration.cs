using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Core.Api.Domain.EntityTypeConfigurations.Identity;

public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.EnableTemporalTable("UserRoles");

        // builder.HasKey(entity => new { entity.UserId, entity.RoleId });
        builder.HasOne(entity => entity.User).WithMany(entity => entity.UserRoles).HasForeignKey(entity => entity.UserId);
        builder.HasOne(entity => entity.Role).WithMany(entity => entity.UserRoles).HasForeignKey(entity => entity.RoleId);
    }
}