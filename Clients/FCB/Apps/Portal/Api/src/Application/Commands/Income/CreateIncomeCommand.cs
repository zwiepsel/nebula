
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income.Handlers;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income;

/// <see cref="CreateIncomeHandler" />
public class CreateIncomeCommand : IEntityCreateCommand<Domain.Entities.Income, IncomeCreateModel>
{
    public CreateIncomeCommand(IncomeCreateModel createModel)
    {
        CreateModel = createModel;
    }

    public IncomeCreateModel CreateModel { get; set; }
}