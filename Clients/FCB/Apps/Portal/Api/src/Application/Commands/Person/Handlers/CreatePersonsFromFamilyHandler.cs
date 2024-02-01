using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

public class CreatePersonsFromFamilyHandler : IRequestHandler<CreatePersonsFromFamilyCommand, List<Domain.Entities.Person>>
{
    private readonly IPersonRepository personRepository;

    public CreatePersonsFromFamilyHandler(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }
    public async Task<List<Domain.Entities.Person>> Handle(CreatePersonsFromFamilyCommand request, CancellationToken cancellationToken)
    {
        var personsToAdd = request.Persons;
        foreach (var person in personsToAdd)
        {
            personRepository.Add(person);
        }

        await personRepository.SaveChangesAsync(cancellationToken);
        return personsToAdd;
    }
}