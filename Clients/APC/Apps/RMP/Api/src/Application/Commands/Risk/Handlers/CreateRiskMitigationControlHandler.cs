using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class CreateRiskMitigationControlHandler : IRequestHandler<CreateRiskMitigationControlCommand,
    Domain.Entities.RiskMitigationControl>
{
    private readonly IRiskRepository riskRepository;

    public CreateRiskMitigationControlHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.RiskMitigationControl> Handle(CreateRiskMitigationControlCommand request,
        CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        var mitigationControl = request.MitigationControl;
        var riskMitigationControl = new Domain.Entities.RiskMitigationControl
        {
            RiskId = risk.Id,
            MitigationControlId = mitigationControl.Id,
            Score = request.Model.Score!.Value
        };

        risk.RiskMitigationControls.Add(riskMitigationControl);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return riskMitigationControl;
    }
}