using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Complex.Handlers;

public class GetAllComplexesHandler : IRequestHandler<GetAllComplexesQuery, IEnumerable<Domain.Entities.Complex>>
{
    private readonly IComplexRepository complexRepository;

    public GetAllComplexesHandler(IComplexRepository complexRepository)
    {
        this.complexRepository = complexRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Complex>> Handle(GetAllComplexesQuery request, CancellationToken cancellationToken)
    {
        return await complexRepository.FindAll(false, cancellationToken);
    }
}