using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.FileType.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.FileType;

/// <see cref="CreateFileTypeHandler" />
public class CreateFileTypeCommand : IRequest<Domain.Entities.FileType>
{
    public CreateFileTypeCommand(FileTypeCreateModel fileTypeCreateModel)
    {
        FileTypeCreateModel = fileTypeCreateModel;
    }

    public FileTypeCreateModel FileTypeCreateModel { get; }
}