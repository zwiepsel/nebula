using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskMitigationControl.Handlers;

public class UpdateRiskMitigationControlHandler : IRequestHandler<UpdateRiskMitigationControlCommand, Domain.Entities.RiskMitigationControl>
{
    private readonly IMapper mapper;
    private readonly IRiskMitigationControlRepository riskMitigationControlRepository;

    public UpdateRiskMitigationControlHandler(IRiskMitigationControlRepository riskMitigationControlRepository, IMapper mapper)
    {
        this.riskMitigationControlRepository = riskMitigationControlRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.RiskMitigationControl> Handle(UpdateRiskMitigationControlCommand request,
        CancellationToken cancellationToken)
    {
        var riskMitigationControl = mapper.Map(request.RiskMitigationControlUpdateModel, request.RiskMitigationControl);

        riskMitigationControlRepository.Update(riskMitigationControl);
        await riskMitigationControlRepository.SaveChangesAsync(cancellationToken);

        return riskMitigationControl;
    }
}