using Nebula.Core.Api.Application.Commands.Client.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.Client;

namespace Nebula.Core.Api.Application.Commands.Client;

/// <see cref="CreateClientHandler" />
public class CreateClientCommand : IEntityCreateCommand<Domain.Entities.Client, ClientCreateModel>
{
    public CreateClientCommand(ClientCreateModel clientCreateModel)
    {
        CreateModel = clientCreateModel;
    }

    public ClientCreateModel CreateModel { get; set; }
}