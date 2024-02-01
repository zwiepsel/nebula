using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Coso;

public class CosoUpdateModelValidator : ModelValidator<CosoUpdateModel>
{
    public CosoUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}