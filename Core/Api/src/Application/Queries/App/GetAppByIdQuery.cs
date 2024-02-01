using Nebula.Core.Api.Application.Queries.App.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Core.Api.Application.Queries.App;

/// <see cref="GetAppByIdHandler" />
public class GetAppByIdQuery : IEntityGetByIdQuery<Domain.Entities.App>
{
    public GetAppByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}