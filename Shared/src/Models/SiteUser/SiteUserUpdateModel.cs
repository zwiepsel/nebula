using System.Collections.Generic;

namespace Nebula.Shared.Models.SiteUser;

public class SiteUserUpdateModel : UpdateModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Password { get; set; }
    public string? ConfirmationPassword { get; set; }
    public int RoleId { get; set; }

    public IDictionary<int, bool> GroupCheckboxValues { get; set; } = new Dictionary<int, bool>();
}