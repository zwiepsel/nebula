using System.Collections.Generic;
using MediatR;

namespace Nebula.Core.Api.Application.Queries.SiteUser;

public class GetSiteUsersBySiteIdQuery : IRequest<IList<Domain.Entities.SiteUser>>
{
    public int SiteId { get; }

    public GetSiteUsersBySiteIdQuery(int siteId)
    {
        SiteId = siteId;
    }
}