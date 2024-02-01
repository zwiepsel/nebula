using Nebula.Shared.Models.User;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.User;

public class UserUpdateModelValidator : ModelValidator<UserUpdateModel>
{
    public UserUpdateModelValidator()
    {
        RuleFor(m => m.Password).IsMinimumLength(8, "Password");
        RuleFor(m => m.ConfirmationPassword).IsMinimumLength(8, "Confirmation password")
            .IsEqual(m => m.Password, "Password", "Confirmation password");
        RuleFor(m => m.RoleId).IsRequired("Role");
    }
}