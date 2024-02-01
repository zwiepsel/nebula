using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income.Handlers;

public class DeleteIncomeHandler : AsyncRequestHandler<DeleteIncomeCommand>
{
    private readonly IIncomeRepository incomeRepository;

    public DeleteIncomeHandler(IIncomeRepository incomeRepository)
    {
        this.incomeRepository = incomeRepository;
    }
    
    protected override async Task Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
    {
        incomeRepository.Delete(request.Income);
        await incomeRepository.SaveChangesAsync(cancellationToken);
    }
}