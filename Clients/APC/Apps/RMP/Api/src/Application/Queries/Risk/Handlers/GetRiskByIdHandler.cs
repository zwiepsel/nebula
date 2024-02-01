using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

public class GetRiskByIdHandler : IRequestHandler<GetRiskByIdQuery, Domain.Entities.Risk?>
{
    private readonly IRiskRepository riskRepository;

    public GetRiskByIdHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk?> Handle(GetRiskByIdQuery request, CancellationToken cancellationToken)
    {
        return await riskRepository.FindById(request.Id);
    }
}