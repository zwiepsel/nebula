using Nebula.Core.Api.Application.Queries.Permission.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.Permission;

/// <see cref="GetPermissionByIdHandler" />
public class GetPermissionByIdQuery : IEntityGetByIdQuery<Domain.Entities.Permission>
{
    public int Id { get; }

    public GetPermissionByIdQuery(int id)
    {
        Id = id;
    }
}