using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

public class CreateRiskDepartmentHandler : IRequestHandler<CreateRiskDepartmentCommand, Domain.Entities.Risk>
{
    private readonly IRiskRepository riskRepository;

    public CreateRiskDepartmentHandler(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<Domain.Entities.Risk> Handle(CreateRiskDepartmentCommand request, CancellationToken cancellationToken)
    {
        var risk = request.Risk;
        risk.Departments.Add(request.Department);

        riskRepository.Update(risk);
        await riskRepository.SaveChangesAsync(cancellationToken);

        return risk;
    }
}