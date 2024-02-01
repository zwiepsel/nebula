using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process;

/// <see cref="UpdateProcessHandler" />
public class UpdateProcessCommand : IRequest<Domain.Entities.Process>
{
    public UpdateProcessCommand(Domain.Entities.Process process, ProcessUpdateModel processUpdateModel)
    {
        Process = process;
        ProcessUpdateModel = processUpdateModel;
    }

    public Domain.Entities.Process Process { get; }
    public ProcessUpdateModel ProcessUpdateModel { get; }
}