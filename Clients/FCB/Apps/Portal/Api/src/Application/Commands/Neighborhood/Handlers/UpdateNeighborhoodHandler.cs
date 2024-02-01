using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood.Handlers;

public class UpdateNeighborhoodHandler : IRequestHandler<UpdateNeighborhoodCommand, Domain.Entities.Neighborhood>
{
    private readonly IMapper mapper;
    private readonly INeighborhoodRepository neighborhoodRepository;

    public UpdateNeighborhoodHandler(INeighborhoodRepository neighborhoodRepository, IMapper mapper)
    {
        this.neighborhoodRepository = neighborhoodRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Neighborhood> Handle(UpdateNeighborhoodCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map(request.UpdateModel, request.Entity);

        neighborhoodRepository.Update(entity);
        await neighborhoodRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}