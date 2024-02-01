using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.App.Handlers;

public class GetAllAppsHandler : IRequestHandler<GetAllAppsQuery, IEnumerable<Domain.Entities.App>>
{
    private readonly IAppRepository appRepository;

    public GetAllAppsHandler(IAppRepository appRepository)
    {
        this.appRepository = appRepository;
    }

    public async Task<IEnumerable<Domain.Entities.App>> Handle(GetAllAppsQuery request, CancellationToken cancellationToken)
    {
        return await appRepository.FindAll(false, cancellationToken);
    }
}