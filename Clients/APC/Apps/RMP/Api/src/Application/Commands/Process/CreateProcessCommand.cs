using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process;

/// <see cref="CreateProcessHandler" />
public class CreateProcessCommand : IRequest<Domain.Entities.Process>
{
    public CreateProcessCommand(ProcessCreateModel processCreateModel)
    {
        ProcessCreateModel = processCreateModel;
    }

    public ProcessCreateModel ProcessCreateModel { get; }
}