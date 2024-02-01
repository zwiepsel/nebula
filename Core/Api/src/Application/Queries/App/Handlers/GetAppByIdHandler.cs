using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.App.Handlers;

public class GetAppByIdHandler : IRequestHandler<GetAppByIdQuery, Domain.Entities.App?>
{
    private readonly IAppRepository appRepository;

    public GetAppByIdHandler(IAppRepository appRepository)
    {
        this.appRepository = appRepository;
    }

    public async Task<Domain.Entities.App?> Handle(GetAppByIdQuery request, CancellationToken cancellationToken)
    {
        return await appRepository.FindById(request.Id);
    }
}