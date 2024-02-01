using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

public class GetAllRisksHandler : IRequestHandler<GetAllRisksQuery, IList<Domain.Entities.Risk>>
{
    private readonly IRiskRepository riskRepository;

    public GetAllRisksHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<IList<Domain.Entities.Risk>> Handle(GetAllRisksQuery request, CancellationToken cancellationToken)
    {
        return await riskRepository.FindAll(false, cancellationToken);
    }
}