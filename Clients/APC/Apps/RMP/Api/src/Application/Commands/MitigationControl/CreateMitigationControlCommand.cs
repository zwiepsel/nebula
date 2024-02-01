using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl;

/// <see cref="CreateMitigationControlHandler" />
public class CreateMitigationControlCommand : IRequest<Domain.Entities.MitigationControl>
{
    public CreateMitigationControlCommand(MitigationControlCreateModel mitigationControlCreateModel)
    {
        MitigationControlCreateModel = mitigationControlCreateModel;
    }

    public MitigationControlCreateModel MitigationControlCreateModel { get; }
}