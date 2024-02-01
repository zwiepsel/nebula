using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood.Handlers;

public class CreateNeighborhoodHandler : IRequestHandler<CreateNeighborhoodCommand, Domain.Entities.Neighborhood>
{
    private readonly IMapper mapper;
    private readonly INeighborhoodRepository neighborhoodRepository;

    public CreateNeighborhoodHandler(INeighborhoodRepository neighborhoodRepository, IMapper mapper)
    {
        this.neighborhoodRepository = neighborhoodRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Neighborhood> Handle(CreateNeighborhoodCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Neighborhood>(request.CreateModel);

        neighborhoodRepository.Add(entity);
        await neighborhoodRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}