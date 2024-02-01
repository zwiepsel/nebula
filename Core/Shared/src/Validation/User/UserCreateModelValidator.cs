using Nebula.Shared.Models.User;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.User;

public class UserCreateModelValidator : ModelValidator<UserCreateModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(m => m.EmailAddress).IsRequired("Email address").IsEmailAddress("Email address");
        RuleFor(m => m.Password).IsRequired("Password").IsValidPassword("Confirmation password");
        RuleFor(m => m.ConfirmationPassword).IsRequired("Confirmation password").IsValidPassword("Confirmation password")
            .IsEqual(m => m.Password, "Password", "Confirmation password");
        RuleFor(m => m.RoleId).IsRequired("Role");
    }
}