using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore.Handlers;

public class UpdateRiskScoreHandler : IRequestHandler<UpdateRiskScoreCommand, Domain.Entities.RiskScore>
{
    private readonly IMapper mapper;
    private readonly IRiskScoreRepository riskScoreRepository;

    public UpdateRiskScoreHandler(IRiskScoreRepository riskScoreRepository, IMapper mapper)
    {
        this.riskScoreRepository = riskScoreRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.RiskScore> Handle(UpdateRiskScoreCommand request, CancellationToken cancellationToken)
    {
        var riskScore = mapper.Map(request.RiskScoreUpdateModel, request.RiskScore);

        riskScoreRepository.Update(riskScore);
        await riskScoreRepository.SaveChangesAsync(cancellationToken);

        return riskScore;
    }
}