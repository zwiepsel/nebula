using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso;

/// <see cref="GetCosoByIdHandler" />
public class GetCosoByIdQuery : IRequest<Domain.Entities.Coso?>
{
    public GetCosoByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}