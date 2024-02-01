using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl.Handlers;

public class GetAllMitigationControlsHandler : IRequestHandler<GetAllMitigationControlsQuery,
    IEnumerable<Domain.Entities.MitigationControl>>
{
    private readonly IMitigationControlRepository mitigationControlRepository;

    public GetAllMitigationControlsHandler(IMitigationControlRepository mitigationControlRepository)
    {
        this.mitigationControlRepository = mitigationControlRepository;
    }

    public async Task<IEnumerable<Domain.Entities.MitigationControl>> Handle(GetAllMitigationControlsQuery request,
        CancellationToken cancellationToken)
    {
        return await mitigationControlRepository.FindAll(false, cancellationToken);
    }
}