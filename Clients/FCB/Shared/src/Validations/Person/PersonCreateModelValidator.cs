using FluentValidation;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Validation;

namespace Nebula.Clients.FCB.Shared.Validations.Person;

public class PersonCreateModelValidator : ModelValidator<PersonCreateModel>
{
    public PersonCreateModelValidator()
    {
        RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Not a valid date");
        RuleFor(m => m.DateOfBirth).IsRequired("Birth date");
        RuleFor(m => m.Gender).IsRequired("Gender");
        RuleFor(m => m.FirstName).IsRequired("First name");
        RuleFor(m => m.LastName).IsRequired("Last name");
    }
}