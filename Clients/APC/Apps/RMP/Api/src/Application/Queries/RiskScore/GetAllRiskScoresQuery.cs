using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore;

/// <see cref="GetAllRiskScoresHandler" />
public class GetAllRiskScoresQuery : IRequest<IEnumerable<Domain.Entities.RiskScore>>
{
}