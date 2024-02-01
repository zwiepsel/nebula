using MediatR;
using Nebula.Core.Api.Application.Queries.Security.Handlers;
using Nebula.Shared.Models.Security;

namespace Nebula.Core.Api.Application.Queries.Security;

/// <see cref="GetApiTokenHandler" />
public class GetApiTokenQuery : IRequest<ApiTokenModel>
{
    public Domain.Entities.Identity.User User { get; }
    public Domain.Entities.Site Site { get; }
    public Domain.Entities.SiteUser? SiteUser { get; }

    public GetApiTokenQuery(Domain.Entities.Identity.User user, Domain.Entities.Site site, Domain.Entities.SiteUser? siteUser = null)
    {
        User = user;
        Site = site;
        SiteUser = siteUser;
    }
}