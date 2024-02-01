using Nebula.Shared.Models.Permission;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Permission;

public class PermissionUpdateModelValidator : ModelValidator<PermissionUpdateModel>
{
    public PermissionUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}