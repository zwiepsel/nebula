using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File;

/// <see cref="GetFileByIdHandler" />
public class GetFileByIdQuery : IRequest<Domain.Entities.File?>
{
    public GetFileByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}