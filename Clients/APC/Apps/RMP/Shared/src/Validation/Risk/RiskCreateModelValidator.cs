using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Risk;

public class RiskCreateModelValidator : ModelValidator<RiskCreateModel>
{
    public RiskCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.ProcessId).IsRequired("Process");
    }
}