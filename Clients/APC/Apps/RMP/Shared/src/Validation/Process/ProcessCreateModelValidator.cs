using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Process;

public class ProcessCreateModelValidator : ModelValidator<ProcessCreateModel>
{
    public ProcessCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}