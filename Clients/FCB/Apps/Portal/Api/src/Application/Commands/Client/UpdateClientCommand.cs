using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client.Handlers;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client;


/// <see cref="UpdateClientHandler" />
public class UpdateClientCommand : IEntityUpdateCommand<Domain.Entities.Client, ClientUpdateModel>
{
    public UpdateClientCommand(Domain.Entities.Client entity, ClientUpdateModel updateModel)
    {
        Entity = entity;
        UpdateModel = updateModel;
    }

    public Domain.Entities.Client Entity { get; set; }
    public ClientUpdateModel UpdateModel { get; set; }
}