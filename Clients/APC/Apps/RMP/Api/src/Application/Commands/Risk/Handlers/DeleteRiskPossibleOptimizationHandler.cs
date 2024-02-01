using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class DeleteRiskPossibleOptimizationHandler : IRequestHandler<DeleteRiskPossibleOptimizationCommand, Domain.Entities.Risk>
{
    private readonly IRiskRepository riskRepository;

    public DeleteRiskPossibleOptimizationHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk> Handle(DeleteRiskPossibleOptimizationCommand request, CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        var mitigationControl = request.MitigationControl;

        risk.RiskPossibleOptimizations =
            risk.RiskPossibleOptimizations.Where(mc => mc.MitigationControlId != mitigationControl.Id).ToList();

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}