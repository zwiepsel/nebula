using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process.Handlers;

public class GetProcessByIdHandler : IRequestHandler<GetProcessByIdQuery, Domain.Entities.Process?>
{
    private readonly IProcessRepository processRepository;

    public GetProcessByIdHandler(IProcessRepository processRepository)
    {
        this.processRepository = processRepository;
    }

    public async Task<Domain.Entities.Process?> Handle(GetProcessByIdQuery request, CancellationToken cancellationToken)
    {
        return await processRepository.FindById(request.Id);
    }
}