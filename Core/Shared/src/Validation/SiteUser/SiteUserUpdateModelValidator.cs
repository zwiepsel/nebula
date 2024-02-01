using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.SiteUser;

public class SiteUserUpdateModelValidator : ModelValidator<SiteUserUpdateModel>
{
    public SiteUserUpdateModelValidator()
    {
        RuleFor(m => m.FirstName).IsRequired("First name");
        RuleFor(m => m.LastName).IsRequired("Last name");
        RuleFor(m => m.Password).IsMinimumLength(8, "Password");
        RuleFor(m => m.ConfirmationPassword).IsMinimumLength(8, "Confirmation password")
            .IsEqual(m => m.Password, "Password", "Confirmation password");
        RuleFor(m => m.RoleId).IsRequired("Role");
    }
}