using System.Collections.Generic;
using System.Linq;
using Nebula.Shared.Models.Role;
using Nebula.Shared.Models.SiteUser;

namespace Nebula.Shared.Models.User;

public class UserViewModel : ViewModel
{
    public string EmailAddress { get; set; } = null!;

    public int RoleId { get; set; }
    public RoleViewModel Role { get; set; } = null!;

    public IList<SiteUserViewModel> SiteUsers { get; set; } = null!;

    public SiteUserViewModel GetSiteUser(int siteId)
    {
        return SiteUsers.First(siteUser => siteUser.Site.Id == siteId);
    }

    public bool IsInRole(string roleName)
    {
        return Role.Name == roleName;
    }
}