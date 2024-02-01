using Nebula.Shared.Models.Security;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Security;

public class PublicRegisterModelValidator : ModelValidator<PublicRegisterModel>
{
    public PublicRegisterModelValidator()
    {
        RuleFor(m => m.EmailAddress).IsRequired("Email address").IsEmailAddress("Email address");
        RuleFor(m => m.Password).IsRequired("Password");
        RuleFor(m => m.ConfirmationPassword).IsRequired("Confirmation password");
        RuleFor(m => m.FirstName).IsRequired("First name");
        RuleFor(m => m.LastName).IsRequired("Last name");
        RuleFor(m => m.SiteId).IsRequired("Site");
    }
}