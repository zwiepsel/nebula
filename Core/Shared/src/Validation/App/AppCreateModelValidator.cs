using Nebula.Shared.Models.App;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.App;

public class AppCreateModelValidator : ModelValidator<AppCreateModel>
{
    public AppCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name");
        RuleFor(m => m.DisplayName).IsRequired("Display name");
        RuleFor(m => m.Path).IsRequired("Path");
        RuleFor(m => m.Icon).IsRequired("Icon");
        RuleFor(m => m.SiteId).IsRequired("Site");
    }
}