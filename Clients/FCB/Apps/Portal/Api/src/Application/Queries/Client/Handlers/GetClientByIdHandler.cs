using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Client.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Domain.Entities.Client?>
{
    private readonly IClientRepository clientRepository;

    public GetClientByIdHandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Domain.Entities.Client?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await clientRepository.FindById(request.Id);
    }
}