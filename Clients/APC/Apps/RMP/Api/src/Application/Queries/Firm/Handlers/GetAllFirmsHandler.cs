using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm.Handlers;

public class GetAllFirmsHandler : IRequestHandler<GetAllFirmsQuery, IEnumerable<Domain.Entities.Firm>>
{
    private readonly IFirmRepository firmRepository;

    public GetAllFirmsHandler(IFirmRepository firmRepository)
    {
        this.firmRepository = firmRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Firm>> Handle(GetAllFirmsQuery request, CancellationToken cancellationToken)
    {
        return await firmRepository.FindAll(false, cancellationToken);
    }
}