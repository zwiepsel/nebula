using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType.Handlers;
using Nebula.Clients.FCB.Shared.Models.FileType;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType;

/// <see cref="CreateFileTypeHandler" />
public class CreateFileTypeCommand : IRequest<Domain.Entities.FileType>
{
    public CreateFileTypeCommand(FileTypeCreateModel fileTypeCreateModel)
    {
        FileTypeCreateModel = fileTypeCreateModel;
    }

    public FileTypeCreateModel FileTypeCreateModel { get; }
}