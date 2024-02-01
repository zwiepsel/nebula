using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl;

/// <see cref="UpdateMitigationControlHandler" />
public class UpdateMitigationControlCommand : IRequest<Domain.Entities.MitigationControl>
{
    public UpdateMitigationControlCommand(Domain.Entities.MitigationControl mitigationControl,
        MitigationControlUpdateModel mitigationControlUpdateModel)
    {
        MitigationControl = mitigationControl;
        MitigationControlUpdateModel = mitigationControlUpdateModel;
    }

    public Domain.Entities.MitigationControl MitigationControl { get; }
    public MitigationControlUpdateModel MitigationControlUpdateModel { get; }
}