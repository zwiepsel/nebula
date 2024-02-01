using Nebula.Shared.Models.Site;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Site;

public class SiteUpdateModelValidator : ModelValidator<SiteUpdateModel>
{
    public SiteUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name");
        RuleFor(m => m.Host).IsRequired("Host");
        RuleFor(m => m.ClientId).IsRequired("Client");
    }
}