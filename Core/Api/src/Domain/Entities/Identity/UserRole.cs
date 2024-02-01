using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Domain.Entities.Identity;

public class UserRole : IdentityUserRole<int>
{
    public virtual User User { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}