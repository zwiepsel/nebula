using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;
/// <see cref="CalculateFieldsHandler" />
public class CalculateFieldsCommand : IRequest<Domain.Entities.Client>
{
    public int ClientId { get; }

    public CalculateFieldsCommand(int clientId)
    {
        ClientId = clientId;
    }
    
}