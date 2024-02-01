using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType.Handlers;
using Nebula.Clients.FCB.Shared.Models.FileType;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType;

/// <see cref="UpdateFileTypeHandler" />
public class UpdateFileTypeCommand : IRequest<Domain.Entities.FileType>
{
    public UpdateFileTypeCommand(Domain.Entities.FileType fileType, FileTypeUpdateModel fileTypeUpdateModel)
    {
        FileType = fileType;
        FileTypeUpdateModel = fileTypeUpdateModel;
    }

    public Domain.Entities.FileType FileType { get; }
    public FileTypeUpdateModel FileTypeUpdateModel { get; }
}