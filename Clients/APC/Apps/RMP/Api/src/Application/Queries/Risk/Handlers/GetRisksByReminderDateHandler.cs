using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

public class GetRisksByReminderDateHandler : IRequestHandler<GetRisksByReminderDateQuery, IList<Domain.Entities.Risk>>
{
    private readonly IRiskRepository riskRepository;

    public GetRisksByReminderDateHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<IList<Domain.Entities.Risk>> Handle(GetRisksByReminderDateQuery request, CancellationToken cancellationToken)
    {
        return await riskRepository.FindByReminderDate(request.ReminderDate, cancellationToken);
    }
}