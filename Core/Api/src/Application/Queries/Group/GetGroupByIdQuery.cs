using Nebula.Core.Api.Application.Queries.Group.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.Group;

/// <see cref="GetGroupByIdHandler" />
public class GetGroupByIdQuery : IEntityGetByIdQuery<Domain.Entities.Group>
{
    public int Id { get; }

    public GetGroupByIdQuery(int id)
    {
        Id = id;
    }
}