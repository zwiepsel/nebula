using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.MitigationControl;

public class MitigationControlLinkModelValidator : ModelValidator<MitigationControlLinkModel>
{
    public MitigationControlLinkModelValidator()
    {
        RuleFor(m => m.MitigationControl).IsRequired("Mitigation control");
        RuleFor(m => m.Score).IsRequired("Score");
    }
}