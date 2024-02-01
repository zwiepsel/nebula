using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Domain.Entities.Person>
{
    private readonly IMapper mapper;
    private readonly IPersonRepository personRepository;

    public CreatePersonHandler(IPersonRepository personRepository, IMapper mapper)
    {
        this.personRepository = personRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Person>(request.CreateModel);

        personRepository.Add(entity);
        await personRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}