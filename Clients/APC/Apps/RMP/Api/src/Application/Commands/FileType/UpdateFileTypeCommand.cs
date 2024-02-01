using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.FileType.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.FileType;

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