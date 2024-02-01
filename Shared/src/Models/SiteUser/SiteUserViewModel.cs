using System.Collections.Generic;
using System.Linq;
using Nebula.Shared.Models.Group;
using Nebula.Shared.Models.Permission;
using Nebula.Shared.Models.Role;
using Nebula.Shared.Models.Site;

namespace Nebula.Shared.Models.SiteUser;

public class SiteUserViewModel : ViewModel
{
    public string EmailAddress { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";

    public virtual IList<GroupViewModel> Groups { get; set; } = null!;
    public virtual IEnumerable<PermissionViewModel> Permissions => Groups.SelectMany(g => g.Permissions);
    
    public RoleViewModel Role { get; set; } = null!;

    public int SiteId { get; set; }
    public SiteViewModel Site { get; set; } = null!;
}