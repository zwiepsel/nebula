using System.Collections.Generic;
using MediatR;

namespace Nebula.Core.Api.Application.Queries.Group;

public class GetGroupsBySiteIdQuery : IRequest<IList<Domain.Entities.Group>>
{
    public int SiteId { get; }

    public GetGroupsBySiteIdQuery(int siteId)
    {
        SiteId = siteId;
    }
}