using Nebula.Core.Api.Application.Queries.User.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.User;

/// <see cref="GetUserByIdHandler" />
public class GetUserByIdQuery : IEntityGetByIdQuery<Domain.Entities.Identity.User>
{
    public GetUserByIdQuery(int userId)
    {
        Id = userId;
    }

    public int Id { get; }
}