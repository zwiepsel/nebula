using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl;

/// <see cref="GetMitigationControlByIdHandler" />
public class GetMitigationControlByIdQuery : IRequest<Domain.Entities.MitigationControl?>
{
    public GetMitigationControlByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}