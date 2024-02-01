using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskMitigationControl.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskMitigationControl;

/// <see cref="GetRiskMitigationControlByIdHandler" />
public class GetRiskMitigationControlByIdQuery : IRequest<Domain.Entities.RiskMitigationControl?>
{
    public GetRiskMitigationControlByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}