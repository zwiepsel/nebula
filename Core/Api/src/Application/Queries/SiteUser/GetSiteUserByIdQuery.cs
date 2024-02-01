using Nebula.Core.Api.Application.Queries.SiteUser.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.SiteUser;

/// <see cref="GetSiteUserByIdHandler" />
public class GetSiteUserByIdQuery : IEntityGetByIdQuery<Domain.Entities.SiteUser>
{
    public int Id { get; }

    public GetSiteUserByIdQuery(int id)
    {
        Id = id;
    }
}