using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore.Handlers;

public class GetRiskScoreByIdHandler : IRequestHandler<GetRiskScoreByIdQuery, Domain.Entities.RiskScore?>
{
    private readonly IRiskScoreRepository riskScoreRepository;

    public GetRiskScoreByIdHandler(IRiskScoreRepository riskScoreRepository)
    {
        this.riskScoreRepository = riskScoreRepository;
    }

    public async Task<Domain.Entities.RiskScore?> Handle(GetRiskScoreByIdQuery request, CancellationToken cancellationToken)
    {
        return await riskScoreRepository.FindById(request.Id);
    }
}