using System.Collections.Generic;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;
/// <see cref="CreatePersonsFromFamilyHandler" />
public class CreatePersonsFromFamilyCommand: IRequest<List<Domain.Entities.Person>>
{
    public List<Domain.Entities.Person> Persons { get; }

    public CreatePersonsFromFamilyCommand(List<Domain.Entities.Person> persons)
    {
        Persons = persons;
    }
}