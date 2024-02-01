using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskPossibleOptimization.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskPossibleOptimization;

/// <see cref="UpdateRiskPossibleOptimizationHandler" />
public class UpdateRiskPossibleOptimizationCommand : IRequest<Domain.Entities.RiskPossibleOptimization>
{
    public UpdateRiskPossibleOptimizationCommand(Domain.Entities.RiskPossibleOptimization riskPossibleOptimization,
        RiskPossibleOptimizationUpdateModel riskPossibleOptimizationUpdateModel)
    {
        RiskPossibleOptimization = riskPossibleOptimization;
        RiskPossibleOptimizationUpdateModel = riskPossibleOptimizationUpdateModel;
    }

    public Domain.Entities.RiskPossibleOptimization RiskPossibleOptimization { get; }
    public RiskPossibleOptimizationUpdateModel RiskPossibleOptimizationUpdateModel { get; }
}