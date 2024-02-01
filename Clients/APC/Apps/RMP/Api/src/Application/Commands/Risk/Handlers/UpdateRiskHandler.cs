using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class UpdateRiskHandler : IRequestHandler<UpdateRiskCommand, Domain.Entities.Risk>
{
    private readonly IMapper mapper;
    private readonly IRiskRepository riskRepository;

    public UpdateRiskHandler(IRiskRepository riskRepository, IMapper mapper)
    {
        this.riskRepository = riskRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Risk> Handle(UpdateRiskCommand request, CancellationToken cancellationToken)
    {
        var risk = mapper.Map(request.RiskUpdateModel, request.Risk);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}