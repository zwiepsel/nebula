using MediatR;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income;

public class DeleteIncomeCommand : IRequest
{
    public DeleteIncomeCommand(Domain.Entities.Income income)
    {
        Income = income;
    }

    public Domain.Entities.Income Income { get; }
}