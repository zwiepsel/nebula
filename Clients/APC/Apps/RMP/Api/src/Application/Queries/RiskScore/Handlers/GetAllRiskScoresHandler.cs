using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore.Handlers;

public class GetAllRiskScoresHandler : IRequestHandler<GetAllRiskScoresQuery, IEnumerable<Domain.Entities.RiskScore>>
{
    private readonly IRiskScoreRepository riskScoreRepository;

    public GetAllRiskScoresHandler(IRiskScoreRepository riskScoreRepository)
    {
        this.riskScoreRepository = riskScoreRepository;
    }

    public async Task<IEnumerable<Domain.Entities.RiskScore>> Handle(GetAllRiskScoresQuery request, CancellationToken cancellationToken)
    {
        return await riskScoreRepository.FindAll(false, cancellationToken);
    }
}