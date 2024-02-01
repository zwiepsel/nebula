using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Neighborhood.Handlers;

public class GetAllNeighborhoodsHandler : IRequestHandler<GetAllNeighborhoodsQuery, IEnumerable<Domain.Entities.Neighborhood>>
{
    private readonly INeighborhoodRepository neighborhoodRepository;

    public GetAllNeighborhoodsHandler(INeighborhoodRepository neighborhoodRepository)
    {
        this.neighborhoodRepository = neighborhoodRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Neighborhood>> Handle(GetAllNeighborhoodsQuery request,
        CancellationToken cancellationToken)
    {
        return await neighborhoodRepository.FindAll(false, cancellationToken);
    }
}