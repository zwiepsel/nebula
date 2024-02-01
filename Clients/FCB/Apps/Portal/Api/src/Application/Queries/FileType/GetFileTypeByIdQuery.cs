using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType;

/// <see cref="GetFileTypeByIdHandler" />
public class GetFileTypeByIdQuery : IRequest<Domain.Entities.FileType?>
{
    public GetFileTypeByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}