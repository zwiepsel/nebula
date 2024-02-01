using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Rent.Handlers;

public class GetAllRentsHandler : IRequestHandler<GetAllRentsQuery, IEnumerable<Domain.Entities.Rent>>
{
    private readonly IRentRepository rentRepository;

    public GetAllRentsHandler(IRentRepository rentRepository)
    {
        this.rentRepository = rentRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Rent>> Handle(GetAllRentsQuery request,
        CancellationToken cancellationToken)
    {
        return await rentRepository.FindAll(false, cancellationToken);
    }
}