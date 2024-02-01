using MediatR;
using Nebula.Core.Api.Application.Queries.Group.Handlers;

namespace Nebula.Core.Api.Application.Queries.Group;

/// <see cref="GetGroupBySiteIdAndSystemNameHandler"/>
public class GetGroupBySiteIdAndSystemNameQuery : IRequest<Domain.Entities.Group?>
{
    public int SiteId { get; }
    public string SystemName { get; }

    public GetGroupBySiteIdAndSystemNameQuery(int siteId, string systemName)
    {
        SiteId = siteId;
        SystemName = systemName;
    }
}