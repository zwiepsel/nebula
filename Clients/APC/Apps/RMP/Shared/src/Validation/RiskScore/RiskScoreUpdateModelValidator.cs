using FluentValidation;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.RiskScore;

public class RiskScoreUpdateModelValidator : ModelValidator<RiskScoreUpdateModel>
{
    public RiskScoreUpdateModelValidator()
    {
        RuleFor(m => m.Frequency).IsRequired("Frequency");
        RuleFor(m => m.Impact).IsRequired("Impact");
        RuleFor(m => m.Type).IsRequired("Type").IsInEnum();
        RuleFor(m => m.Score).IsRequired("Score").IsInRange(1, 3, "Score");
    }
}