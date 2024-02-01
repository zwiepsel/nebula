using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class CreateRiskHandler : IRequestHandler<CreateRiskCommand, Domain.Entities.Risk>
{
    private readonly IMapper mapper;
    private readonly IRiskRepository riskRepository;

    public CreateRiskHandler(IRiskRepository riskRepository, IMapper mapper)
    {
        this.riskRepository = riskRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Risk> Handle(CreateRiskCommand request, CancellationToken cancellationToken)
    {
        var risk = mapper.Map<Domain.Entities.Risk>(request.RiskCreateModel);

        riskRepository.Add(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}