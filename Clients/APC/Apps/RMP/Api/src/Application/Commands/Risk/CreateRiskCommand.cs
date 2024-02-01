using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="CreateRiskHandler" />
public class CreateRiskCommand : IRequest<Domain.Entities.Risk>
{
    public CreateRiskCommand(RiskCreateModel riskCreateModel)
    {
        RiskCreateModel = riskCreateModel;
    }

    public RiskCreateModel RiskCreateModel { get; }
}