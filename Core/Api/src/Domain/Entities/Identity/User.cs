using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Domain.Entities.Identity;

public class User : IdentityUser<int>, IEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string EmailAddress => Email;
    public bool Deleted { get; set; }

    public virtual IList<SiteUser> SiteUsers { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public int? DeletedById { get; set; }
    public virtual User? DeletedBy { get; set; }

    public int? UpdatedById { get; set; }
    public virtual User? UpdatedBy { get; set; }

    public int CreatedById { get; set; }
    public virtual User CreatedBy { get; set; } = null!;

    public virtual IList<UserRole> UserRoles { get; set; } = null!;

    [NotMapped]
    public int RoleId => Role.Id;

    [NotMapped]
    public Role Role => UserRoles.Select(userRole => userRole.Role).First();

    public bool IsInRole(string roleName)
    {
        return Role.Name == roleName;
    }
}