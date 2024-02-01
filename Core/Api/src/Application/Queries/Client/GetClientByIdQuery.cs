using Nebula.Core.Api.Application.Queries.Client.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.Client;

/// <see cref="GetClientByIdHandler" />
public class GetClientByIdQuery : IEntityGetByIdQuery<Domain.Entities.Client>
{
    public GetClientByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}