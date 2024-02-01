using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Firm;

public class FirmUpdateModelValidator : ModelValidator<FirmUpdateModel>
{
    public FirmUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}