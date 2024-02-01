using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;

public class DepartmentUpdateModel : UpdateModel
{
    public string Name { get; set; } = null!;
}