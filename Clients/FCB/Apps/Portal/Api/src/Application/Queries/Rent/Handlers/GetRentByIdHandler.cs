using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Rent.Handlers;

public class GetRentByIdHandler : IRequestHandler<GetRentByIdQuery, Domain.Entities.Rent?>
{
    private readonly IRentRepository rentRepository;

    public GetRentByIdHandler(IRentRepository rentRepository)
    {
        this.rentRepository = rentRepository;
    }

    public async Task<Domain.Entities.Rent?> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
    {
        return await rentRepository.FindById(request.Id);
    }
}