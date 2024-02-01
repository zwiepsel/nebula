using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Domain.Entities.Person>
{
    private readonly IMapper mapper;
    private readonly IPersonRepository personRepository;

    public UpdatePersonHandler(IPersonRepository personRepository, IMapper mapper)
    {
        this.personRepository = personRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map(request.UpdateModel, request.Entity);

        personRepository.Update(entity);
        await personRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}