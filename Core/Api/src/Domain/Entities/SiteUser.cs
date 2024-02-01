using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Core.Api.Domain.Entities.Identity;

namespace Nebula.Core.Api.Domain.Entities;

public class SiteUser : Entity
{
    public string EmailAddress => User.EmailAddress;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PasswordHash { get; set; }
    public string? SecurityStamp { get; set; }

    public int SiteId { get; set; }
    public virtual Site Site { get; set; } = null!;

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    public virtual IList<Group> Groups { get; set; } = new List<Group>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}