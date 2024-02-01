using Nebula.Core.Api.Application.Commands.Client.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.Client;

namespace Nebula.Core.Api.Application.Commands.Client;

/// <see cref="UpdateClientHandler" />
public class UpdateClientCommand : IEntityUpdateCommand<Domain.Entities.Client, ClientUpdateModel>
{
    public UpdateClientCommand(Domain.Entities.Client client, ClientUpdateModel clientUpdateModel)
    {
        Entity = client;
        UpdateModel = clientUpdateModel;
    }

    public Domain.Entities.Client Entity { get; set; }
    public ClientUpdateModel UpdateModel { get; set; }
}