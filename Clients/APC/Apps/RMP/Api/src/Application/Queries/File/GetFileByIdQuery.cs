using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File;

/// <see cref="GetFileByIdHandler" />
public class GetFileByIdQuery : IRequest<Domain.Entities.File?>
{
    public GetFileByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}