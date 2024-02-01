using Nebula.Shared.Models.Client;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Client;

public class ClientUpdateModelValidator : ModelValidator<ClientUpdateModel>
{
    public ClientUpdateModelValidator()
    {
        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name");
    }
}