using Nebula.Shared.Models;
using Nebula.Shared.Utilities;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;

public class DepartmentViewModel : ViewModel
{
    public string Name { get; set; } = null!;

    public string FilterHash => HashGenerator.Sha1(Id);
}