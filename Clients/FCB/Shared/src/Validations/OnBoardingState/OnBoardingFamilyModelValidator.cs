using FluentValidation;
using Nebula.Clients.FCB.Shared.Models.OnboardingState;
using Nebula.Shared.Validation;

namespace Nebula.Clients.FCB.Shared.Validations.OnBoardingState;

public class OnBoardingFamilyModelValidator : ModelValidator<OnBoardingFamilyModel>
{
    public OnBoardingFamilyModelValidator()
    {
        RuleFor(m => m.MainContact.DateOfBirth).NotEmpty().WithMessage("Not a valid date");
        RuleFor(m => m.MainContact.DateOfBirth).IsRequired("Birth date");
        RuleFor(m => m.MainContact.Gender).IsRequired("Gender");
        RuleFor(m => m.MainContact.FirstName).IsRequired("First name");
        RuleFor(m => m.MainContact.LastName).IsRequired("Last name");

        RuleForEach(m => m.Adults).ChildRules(x =>
        {
            x.RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Not a valid date");
            x.RuleFor(m => m.DateOfBirth).IsRequired("Birth date");
            x.RuleFor(m => m.Gender).IsRequired("Gender");
            x.RuleFor(m => m.FirstName).IsRequired("First name");
            x.RuleFor(m => m.LastName).IsRequired("Last name");
        });
        
        RuleForEach(m => m.Children).ChildRules(x =>
        {
            x.RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Not a valid date");
            x.RuleFor(m => m.DateOfBirth).IsRequired("Birth date");
            x.RuleFor(m => m.Gender).IsRequired("Gender");
            x.RuleFor(m => m.FirstName).IsRequired("First name");
            x.RuleFor(m => m.LastName).IsRequired("Last name");
        });

    }
}