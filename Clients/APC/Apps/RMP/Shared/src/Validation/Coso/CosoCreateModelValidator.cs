using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Shared.Validation;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Validation.Coso;

public class CosoCreateModelValidator : ModelValidator<CosoCreateModel>
{
    public CosoCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
    }
}