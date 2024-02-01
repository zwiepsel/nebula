using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.House.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.House;

/// <see cref="GetHouseByIdHandler" />
public class GetHouseByIdQuery : IEntityGetByIdQuery<Domain.Entities.House>
{
    public GetHouseByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}