using System.Collections.Generic;
using MediatR;

namespace Nebula.Core.Api.Application.Queries.Permission;

public class GetPermissionsBySiteIdQuery : IRequest<IList<Domain.Entities.Permission>>
{
    public int SiteId { get; }

    public GetPermissionsBySiteIdQuery(int siteId)
    {
        SiteId = siteId;
    }
}