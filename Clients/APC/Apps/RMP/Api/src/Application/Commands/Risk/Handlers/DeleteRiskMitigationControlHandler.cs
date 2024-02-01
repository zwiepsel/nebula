using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class DeleteRiskMitigationControlHandler : IRequestHandler<DeleteRiskMitigationControlCommand, Domain.Entities.Risk>
{
    private readonly IRiskRepository riskRepository;

    public DeleteRiskMitigationControlHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk> Handle(DeleteRiskMitigationControlCommand request, CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        var mitigationControl = request.MitigationControl;

        risk.RiskMitigationControls = risk.RiskMitigationControls.Where(mc => mc.MitigationControlId != mitigationControl.Id).ToList();

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}