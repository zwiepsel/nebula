using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso.Handlers;

public class GetCosoByIdHandler : IRequestHandler<GetCosoByIdQuery, Domain.Entities.Coso?>
{
    private readonly ICosoRepository cosoRepository;

    public GetCosoByIdHandler(ICosoRepository cosoRepository)
    {
        this.cosoRepository = cosoRepository;
    }

    public async Task<Domain.Entities.Coso?> Handle(GetCosoByIdQuery request, CancellationToken cancellationToken)
    {
        return await cosoRepository.FindById(request.Id, cancellationToken: cancellationToken);
    }
}