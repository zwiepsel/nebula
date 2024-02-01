using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client.Handlers;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Shared.Api.Commands;


namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client;

/// <see cref="CreateClientHandler" />
public class CreateClientCommand : IEntityCreateCommand<Domain.Entities.Client, ClientCreateModel>
{
    public CreateClientCommand(ClientCreateModel createModel)
    {
        CreateModel = createModel;
    }

    public ClientCreateModel CreateModel { get; set; }
}