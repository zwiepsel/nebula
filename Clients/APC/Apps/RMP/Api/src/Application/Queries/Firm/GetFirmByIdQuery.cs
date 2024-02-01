using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm;

/// <see cref="GetFirmByIdHandler" />
public class GetFirmByIdQuery : IRequest<Domain.Entities.Firm?>
{
    public GetFirmByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}