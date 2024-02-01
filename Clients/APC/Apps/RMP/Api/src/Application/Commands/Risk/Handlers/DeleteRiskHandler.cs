using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class DeleteRiskHandler : AsyncRequestHandler<DeleteRiskCommand>
{
    private readonly IRiskRepository riskRepository;

    public DeleteRiskHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    protected override async Task Handle(DeleteRiskCommand request, CancellationToken cancellationToken)
    {
        riskRepository.Delete(request.Risk);
        await riskRepository.SaveChangesAsync(cancellationToken);
    }
}