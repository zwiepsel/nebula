using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskPossibleOptimization.Handlers;

public class UpdateRiskPossibleOptimizationHandler : IRequestHandler<UpdateRiskPossibleOptimizationCommand,
    Domain.Entities.RiskPossibleOptimization>
{
    private readonly IMapper mapper;
    private readonly IRiskPossibleOptimizationRepository riskPossibleOptimizationRepository;

    public UpdateRiskPossibleOptimizationHandler(IRiskPossibleOptimizationRepository riskPossibleOptimizationRepository, IMapper mapper)
    {
        this.riskPossibleOptimizationRepository = riskPossibleOptimizationRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.RiskPossibleOptimization> Handle(UpdateRiskPossibleOptimizationCommand request,
        CancellationToken cancellationToken)
    {
        var riskPossibleOptimization = mapper.Map(request.RiskPossibleOptimizationUpdateModel, request.RiskPossibleOptimization);

        riskPossibleOptimizationRepository.Update(riskPossibleOptimization);
        await riskPossibleOptimizationRepository.SaveChangesAsync(cancellationToken);

        return riskPossibleOptimization;
    }
}