using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class DeleteRiskDepartmentHandler : IRequestHandler<DeleteRiskDepartmentCommand, Domain.Entities.Risk>
{
    private readonly IRiskRepository riskRepository;

    public DeleteRiskDepartmentHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk> Handle(DeleteRiskDepartmentCommand request, CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        risk.Departments.Remove(request.Department);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}