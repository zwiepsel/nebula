using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House.Handlers;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House;

/// <see cref="CreateHouseHandler" />
public class CreateHouseCommand : IEntityCreateCommand<Domain.Entities.House, HouseCreateModel>
{
    public CreateHouseCommand(HouseCreateModel createModel)
    {
        CreateModel = createModel;
    }

    public HouseCreateModel CreateModel { get; set; }
}