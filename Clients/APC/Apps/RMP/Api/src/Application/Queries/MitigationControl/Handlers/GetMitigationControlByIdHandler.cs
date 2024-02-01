using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl.Handlers;

public class GetMitigationControlByIdHandler : IRequestHandler<GetMitigationControlByIdQuery, Domain.Entities.MitigationControl?>
{
    private readonly IMitigationControlRepository mitigationControlRepository;

    public GetMitigationControlByIdHandler(IMitigationControlRepository mitigationControlRepository)
    {
        this.mitigationControlRepository = mitigationControlRepository;
    }

    public async Task<Domain.Entities.MitigationControl?> Handle(GetMitigationControlByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await mitigationControlRepository.FindById(request.Id);
    }
}