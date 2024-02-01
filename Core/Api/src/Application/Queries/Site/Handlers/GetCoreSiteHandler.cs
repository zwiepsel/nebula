using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Site.Handlers;

public class GetCoreSiteHandler : IRequestHandler<GetCoreSiteQuery, Domain.Entities.Site>
{
    private readonly ISiteRepository siteRepository;

    public GetCoreSiteHandler(ISiteRepository siteRepository)
    {
        this.siteRepository = siteRepository;
    }

    public async Task<Domain.Entities.Site> Handle(GetCoreSiteQuery request, CancellationToken cancellationToken)
    {
        return await siteRepository.GetCore(cancellationToken);
    }
}