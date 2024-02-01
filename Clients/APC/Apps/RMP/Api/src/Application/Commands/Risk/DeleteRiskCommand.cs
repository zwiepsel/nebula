using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="DeleteRiskHandler" />
public class DeleteRiskCommand : IRequest
{
    public DeleteRiskCommand(Domain.Entities.Risk risk)
    {
        Risk = risk;
    }

    public Domain.Entities.Risk Risk { get; }
}