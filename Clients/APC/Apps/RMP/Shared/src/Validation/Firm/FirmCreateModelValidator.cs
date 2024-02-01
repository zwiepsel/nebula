using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Firm;

public class FirmCreateModelValidator : ModelValidator<FirmCreateModel>
{
    public FirmCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}