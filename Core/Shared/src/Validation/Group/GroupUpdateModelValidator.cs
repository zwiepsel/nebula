using Nebula.Shared.Models.Group;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Group;

public class GroupUpdateModelValidator : ModelValidator<GroupUpdateModel>
{
    public GroupUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}