using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskPossibleOptimization.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskPossibleOptimization;

/// <see cref="GetRiskPossibleOptimizationByIdHandler" />
public class GetRiskPossibleOptimizationByIdQuery : IRequest<Domain.Entities.RiskPossibleOptimization?>
{
    public GetRiskPossibleOptimizationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}