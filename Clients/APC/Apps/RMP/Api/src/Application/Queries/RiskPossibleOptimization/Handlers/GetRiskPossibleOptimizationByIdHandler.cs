using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskPossibleOptimization.Handlers;

public class GetRiskPossibleOptimizationByIdHandler : IRequestHandler<GetRiskPossibleOptimizationByIdQuery,
    Domain.Entities.RiskPossibleOptimization?>
{
    private readonly IRiskPossibleOptimizationRepository riskPossibleOptimizationRepository;

    public GetRiskPossibleOptimizationByIdHandler(IRiskPossibleOptimizationRepository riskPossibleOptimizationRepository)
    {
        this.riskPossibleOptimizationRepository = riskPossibleOptimizationRepository;
    }

    public async Task<Domain.Entities.RiskPossibleOptimization?> Handle(GetRiskPossibleOptimizationByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await riskPossibleOptimizationRepository.FindById(request.Id);
    }
}