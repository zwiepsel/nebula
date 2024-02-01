using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process;

/// <see cref="GetProcessByIdHandler" />
public class GetProcessByIdQuery : IRequest<Domain.Entities.Process?>
{
    public GetProcessByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}