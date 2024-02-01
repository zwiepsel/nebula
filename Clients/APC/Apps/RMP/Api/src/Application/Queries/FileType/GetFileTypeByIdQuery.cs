using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.FileType.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.FileType;

/// <see cref="GetFileTypeByIdHandler" />
public class GetFileTypeByIdQuery : IRequest<Domain.Entities.FileType?>
{
    public GetFileTypeByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}