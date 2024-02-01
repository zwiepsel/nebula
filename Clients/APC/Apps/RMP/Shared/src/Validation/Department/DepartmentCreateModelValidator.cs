using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Department;

public class DepartmentCreateModelValidator : ModelValidator<DepartmentCreateModel>
{
    public DepartmentCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}