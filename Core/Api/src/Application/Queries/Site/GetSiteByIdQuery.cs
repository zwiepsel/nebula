using Nebula.Core.Api.Application.Queries.Site.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.Site;

/// <see cref="GetSiteByIdHandler" />
public class GetSiteByIdQuery : IEntityGetByIdQuery<Domain.Entities.Site>
{
    public GetSiteByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}