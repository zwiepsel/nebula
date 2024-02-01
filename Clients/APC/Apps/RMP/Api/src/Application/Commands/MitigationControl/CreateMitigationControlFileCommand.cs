using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl;

/// <see cref="CreateMitigationControlFileHandler" />
public class CreateMitigationControlFileCommand : IRequest<Domain.Entities.MitigationControl>
{
    public CreateMitigationControlFileCommand(Domain.Entities.MitigationControl mitigationControl, Domain.Entities.File file)
    {
        MitigationControl = mitigationControl;
        File = file;
    }

    public Domain.Entities.MitigationControl MitigationControl { get; }
    public Domain.Entities.File File { get; }
}