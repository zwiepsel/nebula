using FluentValidation;
using Nebula.Clients.FCB.Shared.Models.File;
using Nebula.Shared.Validation;

namespace Nebula.Clients.FCB.Shared.Validations.File;

public class FileCreateModelValidator: ModelValidator<FileCreateModel>
{
    public FileCreateModelValidator()
    {
        RuleFor(m => m.Name).NotEmpty().WithMessage("U dient een bestand te selecteren");
    }
    
}