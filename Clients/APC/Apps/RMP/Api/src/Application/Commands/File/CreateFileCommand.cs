using MediatR;
using Microsoft.AspNetCore.Http;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File;

/// <see cref="CreateFileHandler" />
public class CreateFileCommand : IRequest<Domain.Entities.File>
{
    public CreateFileCommand(IFormFile formFile, string fileName, int fileTypeId)
    {
        FormFile = formFile;
        FileName = fileName;
        FileTypeId = fileTypeId;
    }

    public IFormFile FormFile { get; }
    public string FileName { get; }
    public int FileTypeId { get; }
}