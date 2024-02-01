using FluentValidation;
using Nebula.Shared.Validation;

namespace Nebula.Clients.FCB.Shared.Validations.OnBoardingState;

public class OnBoardingStateValidator: ModelValidator<Models.OnboardingState.OnBoardingState>
{
    public OnBoardingStateValidator()
    {
        RuleFor(m => m.IncomeScaleId).NotEqual(0).WithMessage("Selecteer een inkomen schaal");
    }
}