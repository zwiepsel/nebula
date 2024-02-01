using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class CreateRiskPossibleOptimizationHandler : IRequestHandler<CreateRiskPossibleOptimizationCommand,
    Domain.Entities.RiskPossibleOptimization>
{
    private readonly IRiskRepository riskRepository;

    public CreateRiskPossibleOptimizationHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.RiskPossibleOptimization> Handle(CreateRiskPossibleOptimizationCommand request,
        CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        var mitigationControl = request.MitigationControl;
        var riskPossibleOptimization = new Domain.Entities.RiskPossibleOptimization
        {
            RiskId = risk.Id,
            MitigationControlId = mitigationControl.Id,
            Score = request.Model.Score!.Value
        };

        risk.RiskPossibleOptimizations.Add(riskPossibleOptimization);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return riskPossibleOptimization;
    }
}