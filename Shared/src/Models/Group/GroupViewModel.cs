using System.Collections.Generic;
using Nebula.Shared.Models.Permission;

namespace Nebula.Shared.Models.Group;

public class GroupViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;

    public IList<PermissionViewModel> Permissions { get; set; } = null!;
}