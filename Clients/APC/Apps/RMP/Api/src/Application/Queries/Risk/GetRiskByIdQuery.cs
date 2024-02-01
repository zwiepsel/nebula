using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk;

/// <see cref="GetRiskByIdHandler" />
public class GetRiskByIdQuery : IRequest<Domain.Entities.Risk?>
{
    public GetRiskByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}