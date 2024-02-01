using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File;

/// <see cref="DeleteFileHandler" />
public class DeleteFileCommand : IRequest
{
    public DeleteFileCommand(Domain.Entities.File file)
    {
        File = file;
    }

    public Domain.Entities.File File { get; }
}