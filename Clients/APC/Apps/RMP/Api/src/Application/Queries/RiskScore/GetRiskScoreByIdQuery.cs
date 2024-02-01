using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore;

/// <see cref="GetRiskScoreByIdHandler" />
public class GetRiskScoreByIdQuery : IRequest<Domain.Entities.RiskScore?>
{
    public GetRiskScoreByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}