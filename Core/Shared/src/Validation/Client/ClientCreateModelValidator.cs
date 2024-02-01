using Nebula.Shared.Models.Client;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Client;

public class ClientCreateModelValidator : ModelValidator<ClientCreateModel>
{
    public ClientCreateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name");
    }
}