using MediatR;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;

public class DeletePersonCommand : IRequest
{
    public DeletePersonCommand(Domain.Entities.Person person)
    {
        Person = person;
    }

    public Domain.Entities.Person Person { get; }
}