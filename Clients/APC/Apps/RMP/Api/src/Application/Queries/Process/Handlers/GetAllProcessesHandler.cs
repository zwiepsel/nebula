using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process.Handlers;

public class GetAllProcessesHandler : IRequestHandler<GetAllProcessesQuery, IEnumerable<Domain.Entities.Process>>
{
    private readonly IProcessRepository processRepository;

    public GetAllProcessesHandler(IProcessRepository processRepository)
    {
        this.processRepository = processRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Process>> Handle(GetAllProcessesQuery request, CancellationToken cancellationToken)
    {
        return await processRepository.FindAll(false, cancellationToken);
    }
}