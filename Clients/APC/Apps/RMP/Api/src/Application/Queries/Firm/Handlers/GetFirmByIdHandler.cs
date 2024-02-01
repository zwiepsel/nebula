using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm.Handlers;

public class GetFirmByIdHandler : IRequestHandler<GetFirmByIdQuery, Domain.Entities.Firm?>
{
    private readonly IFirmRepository firmRepository;

    public GetFirmByIdHandler(IFirmRepository firmRepository)
    {
        this.firmRepository = firmRepository;
    }

    public async Task<Domain.Entities.Firm?> Handle(GetFirmByIdQuery request, CancellationToken cancellationToken)
    {
        return await firmRepository.FindById(request.Id);
    }
}