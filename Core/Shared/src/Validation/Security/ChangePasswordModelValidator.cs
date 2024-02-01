using Nebula.Shared.Models.Security;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Security;

public class ChangePasswordModelValidator : ModelValidator<ChangePasswordModel>
{
    public ChangePasswordModelValidator()
    {
        RuleFor(m => m.CurrentPassword).IsRequired("Current password");
        RuleFor(m => m.NewPassword).IsRequired("New password").IsValidPassword("New password");
        RuleFor(m => m.ConfirmationPassword).IsRequired("Confirmation password").IsValidPassword("Confirmation password")
            .IsEqual(m => m.NewPassword, "New password", "Confirmation password");
    }
}