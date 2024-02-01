using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class CreateRiskFileHandler : IRequestHandler<CreateRiskFileCommand, Domain.Entities.Risk>
{
    private readonly IRiskRepository riskRepository;

    public CreateRiskFileHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk> Handle(CreateRiskFileCommand request, CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        risk.Files.Add(request.File);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}