using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Site.Handlers;

public class GetAllSitesHandler : IRequestHandler<GetAllSitesQuery, IEnumerable<Domain.Entities.Site>>
{
    private readonly ISiteRepository siteRepository;

    public GetAllSitesHandler(ISiteRepository siteRepository)
    {
        this.siteRepository = siteRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Site>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
    {
        return await siteRepository.FindAll(false, cancellationToken);
    }
}