using Nebula.Shared.Models.Site;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Site;

public class SiteCreateModelValidator : ModelValidator<SiteCreateModel>
{
    public SiteCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name");
        RuleFor(m => m.Host).IsRequired("Host");
        RuleFor(m => m.ClientId).IsRequired("Client");
    }
}