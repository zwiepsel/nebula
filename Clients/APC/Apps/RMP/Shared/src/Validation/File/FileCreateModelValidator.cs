using Nebula.Clients.APC.Apps.RMP.Shared.Models.File;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.File;

public class FileTypeCreateModelValidator : ModelValidator<FileCreateModel>
{
    public FileTypeCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.FileTypeId).IsRequired("File type");
        RuleFor(m => m.BrowserFile).IsRequired("File");
    }
}