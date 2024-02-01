using FluentValidation;
using Nebula.Clients.FCB.Shared.Models.User;
using Nebula.Shared.Validation;

namespace Nebula.Clients.FCB.Shared.Validations.User;

public class RegisterUserCreateModelValidator : ModelValidator<RegisterUserModel>
{
    public RegisterUserCreateModelValidator()
    {
        RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Not a valid date");
        RuleFor(m => m.EmailAddress).IsRequired("Email address").IsEmailAddress("Email address");
        RuleFor(m => m.Gender).NotEmpty().WithMessage("Please select a gender");
        RuleFor(m => m.FirstName).NotEmpty().WithMessage("Firstname is required");
        RuleFor(m => m.LastName).NotEmpty().WithMessage("Lastname is required");
        RuleFor(m => m.Password).NotEmpty().WithMessage("password is required").IsValidPassword("password");
        RuleFor(m => m.ConfirmationPassword).NotEmpty().WithMessage("new password is required").IsValidPassword("password");
        RuleFor(m => m.ConfirmationPassword).IsRequired("Confirmation password").IsValidPassword("Confirmation password")
            .IsEqual(m => m.Password, "Password", "Confirmation password");
        RuleFor(m => m.AgreeTerms).Must(x => x).WithMessage("You need to agree with the Terms and Conditions");
    }
}