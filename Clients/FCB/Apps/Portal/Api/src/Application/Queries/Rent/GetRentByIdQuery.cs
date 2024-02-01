using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Rent.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Rent;

/// <see cref="GetRentByIdHandler" />
public class GetRentByIdQuery : IEntityGetByIdQuery<Domain.Entities.Rent>
{
    public GetRentByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}