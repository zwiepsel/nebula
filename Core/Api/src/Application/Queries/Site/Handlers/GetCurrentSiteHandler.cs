using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Site.Handlers;

public class GetCurrentSiteHandler : IRequestHandler<GetCurrentSiteQuery, Domain.Entities.Site?>
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly ISiteRepository siteRepository;

    public GetCurrentSiteHandler(IHttpContextAccessor httpContextAccessor, ISiteRepository siteRepository)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.siteRepository = siteRepository;
    }

    public async Task<Domain.Entities.Site?> Handle(GetCurrentSiteQuery request, CancellationToken cancellationToken)
    {
        var currentSiteClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid);

        // Site claim found in the user claims principal.
        if (currentSiteClaim != null)
        {
            if (int.TryParse(currentSiteClaim.Value, out var currentSiteId))
            {
                return await siteRepository.FindById(currentSiteId, cancellationToken);
            }
        }

        return null;
    }
}