using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.IncomeScale.Handlers;

public class GetIncomeScaleHandler: IRequestHandler<GetIncomeScaleQuery, IEnumerable<Domain.Entities.IncomeScale>>
{
    private readonly IIncomeScaleRepository incomeScaleRepository;

    public GetIncomeScaleHandler(IIncomeScaleRepository incomeScaleRepository)
    {
        this.incomeScaleRepository = incomeScaleRepository;
    }

    public async Task<IEnumerable<Domain.Entities.IncomeScale>> Handle(GetIncomeScaleQuery request, CancellationToken cancellationToken)
    {
        return await incomeScaleRepository.FindAll(false, cancellationToken);
    }
}