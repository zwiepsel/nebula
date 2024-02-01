using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore.Handlers;

public class CreateRiskScoreHandler : IRequestHandler<CreateRiskScoreCommand, Domain.Entities.RiskScore>
{
    private readonly IMapper mapper;
    private readonly IRiskScoreRepository riskScoreRepository;

    public CreateRiskScoreHandler(IRiskScoreRepository riskScoreRepository, IMapper mapper)
    {
        this.riskScoreRepository = riskScoreRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.RiskScore> Handle(CreateRiskScoreCommand request, CancellationToken cancellationToken)
    {
        var riskScore = mapper.Map<Domain.Entities.RiskScore>(request.RiskScoreCreateModel);

        riskScoreRepository.Add(riskScore);
        await riskScoreRepository.SaveChangesAsync(cancellationToken);

        return riskScore;
    }
}