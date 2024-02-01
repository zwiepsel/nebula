using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Department;

public class DepartmentUpdateModelValidator : ModelValidator<DepartmentUpdateModel>
{
    public DepartmentUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}