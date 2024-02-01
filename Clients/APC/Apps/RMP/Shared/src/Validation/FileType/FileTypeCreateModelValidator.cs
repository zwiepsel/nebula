using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.FileType;

public class FileTypeCreateModelValidator : ModelValidator<FileTypeCreateModel>
{
    public FileTypeCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}