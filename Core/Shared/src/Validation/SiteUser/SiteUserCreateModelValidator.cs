using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.SiteUser;

public class SiteUserCreateModelValidator : ModelValidator<SiteUserCreateModel>
{
    public SiteUserCreateModelValidator()
    {
        RuleFor(m => m.FirstName).IsRequired("First name");
        RuleFor(m => m.LastName).IsRequired("Last name");
        RuleFor(m => m.EmailAddress).IsRequired("Email address").IsEmailAddress("Email address");
        RuleFor(m => m.Password).IsRequired("Password").IsValidPassword("Confirmation password");
        RuleFor(m => m.ConfirmationPassword).IsRequired("Confirmation password").IsValidPassword("Confirmation password")
            .IsEqual(m => m.Password, "Password", "Confirmation password");
        RuleFor(m => m.RoleId).IsRequired("Role");
    }
}