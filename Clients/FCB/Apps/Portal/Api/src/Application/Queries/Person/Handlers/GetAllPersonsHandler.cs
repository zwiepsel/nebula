using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Person.Handlers;

public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Domain.Entities.Person>>
{
    private readonly IPersonRepository personRepository;

    public GetAllPersonsHandler(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
    {
        return await personRepository.FindAll(false, cancellationToken);
    }
}