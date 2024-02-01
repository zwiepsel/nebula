using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.SiteUser.Handlers;

public class GetSiteUsersBySiteIdHandler : IRequestHandler<GetSiteUsersBySiteIdQuery, IList<Domain.Entities.SiteUser>>
{
    private readonly ISiteUserRepository siteUserRepository;

    public GetSiteUsersBySiteIdHandler(ISiteUserRepository siteUserRepository)
    {
        this.siteUserRepository = siteUserRepository;
    }

    public async Task<IList<Domain.Entities.SiteUser>> Handle(GetSiteUsersBySiteIdQuery request, CancellationToken cancellationToken)
    {
        return await siteUserRepository.FindBySiteId(request.SiteId, cancellationToken);
    }
}