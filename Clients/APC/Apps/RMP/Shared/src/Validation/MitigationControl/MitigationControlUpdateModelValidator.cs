using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.MitigationControl;

public class MitigationControlUpdateModelValidator : ModelValidator<MitigationControlUpdateModel>
{
    public MitigationControlUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.ShortName).IsRequired("Short name");
        RuleFor(m => m.Description).IsRequired("Description");
        RuleFor(m => m.ControlType).IsRequired("Control type");
        RuleFor(m => m.Trigger).IsRequired("Trigger");
    }
}