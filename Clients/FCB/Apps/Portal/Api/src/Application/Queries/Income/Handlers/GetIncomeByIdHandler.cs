using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Income.Handlers;

public class GetIncomeByIdHandler : IRequestHandler<GetIncomeByIdQuery, Domain.Entities.Income?>
{
    private readonly IIncomeRepository incomeRepository;

    public GetIncomeByIdHandler(IIncomeRepository incomeRepository)
    {
        this.incomeRepository = incomeRepository;
    }

    public async Task<Domain.Entities.Income?> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
    {
        return await incomeRepository.FindById(request.Id);
    }
}