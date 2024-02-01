using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.House.Handlers;

public class GetAllHousesHandler : IRequestHandler<GetAllHousesQuery, IEnumerable<Domain.Entities.House>>
{
    private readonly IHouseRepository houseRepository;

    public GetAllHousesHandler(IHouseRepository houseRepository)
    {
        this.houseRepository = houseRepository;
    }

    public async Task<IEnumerable<Domain.Entities.House>> Handle(GetAllHousesQuery request, CancellationToken cancellationToken)
    {
        return await houseRepository.FindAll(false, cancellationToken);
    }
}