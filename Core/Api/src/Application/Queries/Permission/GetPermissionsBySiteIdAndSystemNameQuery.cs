using MediatR;
using Nebula.Core.Api.Application.Queries.Permission.Handlers;

namespace Nebula.Core.Api.Application.Queries.Permission;

/// <see cref="GetPermissionBySiteIdAndSystemNameHandler"/>
public class GetPermissionBySiteIdAndSystemNameQuery : IRequest<Domain.Entities.Permission?>
{
    public int SiteId { get; }
    public string SystemName { get; }

    public GetPermissionBySiteIdAndSystemNameQuery(int siteId, string systemName)
    {
        SiteId = siteId;
        SystemName = systemName;
    }
}