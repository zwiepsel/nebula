using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso.Handlers;

public class GetAllCososHandler : IRequestHandler<GetAllCososQuery, IEnumerable<Domain.Entities.Coso>>
{
    private readonly ICosoRepository cosoRepository;

    public GetAllCososHandler(ICosoRepository cosoRepository)
    {
        this.cosoRepository = cosoRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Coso>> Handle(GetAllCososQuery request, CancellationToken cancellationToken)
    {
        return await cosoRepository.FindAll(false, cancellationToken);
    }
}