using Nebula.Shared.Models.Security;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Security;

public class SignInModelValidator : ModelValidator<SignInModel>
{
    public SignInModelValidator()
    {
        RuleFor(m => m.EmailAddress).IsRequired("Email address").IsEmailAddress("Email address");
        RuleFor(m => m.Password).IsRequired("Password");
        RuleFor(m => m.SiteId).IsRequired("Site");
    }
}