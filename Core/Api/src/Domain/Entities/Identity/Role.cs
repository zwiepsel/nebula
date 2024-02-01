using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Domain.Enums;

namespace Nebula.Core.Api.Domain.Entities.Identity;

public class Role : IdentityRole<int>, IEntity
{
    public RoleType Type { get; set; }

    public bool Deleted { get; set; }

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
}