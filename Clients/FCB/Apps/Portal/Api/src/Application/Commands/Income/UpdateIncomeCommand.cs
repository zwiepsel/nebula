using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income.Handlers;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income;

/// <see cref="UpdateIncomeHandler" />
public class UpdateIncomeCommand : IEntityUpdateCommand<Domain.Entities.Income, IncomeUpdateModel>
{
    public UpdateIncomeCommand(Domain.Entities.Income entity, IncomeUpdateModel updateModel)
    {
        Entity = entity;
        UpdateModel = updateModel;
    }

    public Domain.Entities.Income Entity { get; set; }
    public IncomeUpdateModel UpdateModel { get; set; }
}