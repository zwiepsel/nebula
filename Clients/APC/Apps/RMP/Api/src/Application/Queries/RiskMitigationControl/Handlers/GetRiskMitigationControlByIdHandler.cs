using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskMitigationControl.Handlers;

public class GetRiskMitigationControlByIdHandler : IRequestHandler<GetRiskMitigationControlByIdQuery, Domain.Entities.RiskMitigationControl
    ?>
{
    private readonly IRiskMitigationControlRepository riskMitigationControlRepository;

    public GetRiskMitigationControlByIdHandler(IRiskMitigationControlRepository riskMitigationControlRepository)
    {
        this.riskMitigationControlRepository = riskMitigationControlRepository;
    }

    public async Task<Domain.Entities.RiskMitigationControl?> Handle(GetRiskMitigationControlByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await riskMitigationControlRepository.FindById(request.Id);
    }
}