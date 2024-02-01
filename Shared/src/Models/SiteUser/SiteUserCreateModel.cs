using System.Collections.Generic;

namespace Nebula.Shared.Models.SiteUser;

public class SiteUserCreateModel : CreateModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmationPassword { get; set; } = null!;
    public int RoleId { get; set; }

    public IDictionary<int, bool> GroupCheckboxValues { get; set; } = new Dictionary<int, bool>();
}