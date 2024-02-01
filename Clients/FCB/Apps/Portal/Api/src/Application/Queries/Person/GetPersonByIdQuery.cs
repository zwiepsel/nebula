using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Person.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Person;

/// <see cref="GetPersonByIdHandler" />
public class GetPersonByIdQuery : IEntityGetByIdQuery<Domain.Entities.Person>
{
    public GetPersonByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}