using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Neighborhood.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Neighborhood;

/// <see cref="GetNeighborhoodByIdHandler" />
public class GetNeighborhoodByIdQuery : IEntityGetByIdQuery<Domain.Entities.Neighborhood>
{
    public GetNeighborhoodByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}