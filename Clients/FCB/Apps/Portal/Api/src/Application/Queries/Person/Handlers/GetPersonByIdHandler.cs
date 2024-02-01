using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Person.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Domain.Entities.Person?>
{
    private readonly IPersonRepository personRepository;

    public GetPersonByIdHandler(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    public async Task<Domain.Entities.Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await personRepository.FindById(request.Id, cancellationToken: cancellationToken);
    }
}