using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Neighborhood.Handlers;

public class GetNeighborhoodByIdHandler : IRequestHandler<GetNeighborhoodByIdQuery, Domain.Entities.Neighborhood?>
{
    private readonly INeighborhoodRepository neighborhoodRepository;

    public GetNeighborhoodByIdHandler(INeighborhoodRepository neighborhoodRepository)
    {
        this.neighborhoodRepository = neighborhoodRepository;
    }

    public async Task<Domain.Entities.Neighborhood?> Handle(GetNeighborhoodByIdQuery request, CancellationToken cancellationToken)
    {
        return await neighborhoodRepository.FindById(request.Id);
    }
}