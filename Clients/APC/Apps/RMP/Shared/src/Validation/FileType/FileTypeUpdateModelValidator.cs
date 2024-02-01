using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.FileType;

public class FileTypeUpdateModelValidator : ModelValidator<FileTypeUpdateModel>
{
    public FileTypeUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}