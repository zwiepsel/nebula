using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.House.Handlers;

public class GetHouseByIdHandler : IRequestHandler<GetHouseByIdQuery, Domain.Entities.House?>
{
    private readonly IHouseRepository houseRepository;

    public GetHouseByIdHandler(IHouseRepository houseRepository)
    {
        this.houseRepository = houseRepository;
    }

    public async Task<Domain.Entities.House?> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken)
    {
        return await houseRepository.FindById(request.Id);
    }
}