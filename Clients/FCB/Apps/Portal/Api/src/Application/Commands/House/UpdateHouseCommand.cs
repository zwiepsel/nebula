using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House.Handlers;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House;

/// <see cref="UpdateHouseHandler" />
public class UpdateHouseCommand : IEntityUpdateCommand<Domain.Entities.House, HouseUpdateModel>
{
    public UpdateHouseCommand(Domain.Entities.House entity, HouseUpdateModel updateModel)
    {
        Entity = entity;
        UpdateModel = updateModel;
    }

    public Domain.Entities.House Entity { get; set; }
    public HouseUpdateModel UpdateModel { get; set; }
}