using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Site.Handlers;

public class GetSiteByHostHandler : IRequestHandler<GetSiteByHostQuery, Domain.Entities.Site?>
{
    private readonly ISiteRepository siteRepository;

    public GetSiteByHostHandler(ISiteRepository siteRepository)
    {
        this.siteRepository = siteRepository;
    }

    public async Task<Domain.Entities.Site?> Handle(GetSiteByHostQuery request, CancellationToken cancellationToken)
    {
        return await siteRepository.FindByHost(request.Host, cancellationToken);
    }
}