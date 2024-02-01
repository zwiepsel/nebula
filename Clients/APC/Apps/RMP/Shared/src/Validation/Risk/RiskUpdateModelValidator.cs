using FluentValidation;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Risk;

public class RiskUpdateModelValidator : ModelValidator<RiskUpdateModel>
{
    public RiskUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.ProcessId).IsRequired("Process");
        RuleFor(m => m.ReviewDate).GreaterThanOrEqualTo(m => m.IdentificationDate)
            .WithMessage("Review date must be greater than or equal to identification date.");
        RuleFor(m => m.ReminderDate).GreaterThanOrEqualTo(m => m.IdentificationDate)
            .WithMessage("Reminder date must be greater than or equal to identification date.");
    }
}