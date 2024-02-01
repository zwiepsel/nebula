using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Income.Handlers;

public class GetAllIncomesHandler : IRequestHandler<GetAllIncomesQuery, IEnumerable<Domain.Entities.Income>>
{
    private readonly IIncomeRepository incomeRepository;

    public GetAllIncomesHandler(IIncomeRepository incomeRepository)
    {
        this.incomeRepository = incomeRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Income>> Handle(GetAllIncomesQuery request,
        CancellationToken cancellationToken)
    {
        return await incomeRepository.FindAll(false, cancellationToken);
    }
}