using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.FileSystem;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File.Handlers;

public class CreateFileHandler : IRequestHandler<CreateFileCommand, Domain.Entities.File>
{
    private readonly IFileRepository fileRepository;
    private readonly IFileSystem fileSystem;

    public CreateFileHandler(IFileRepository fileRepository, IFileSystem fileSystem)
    {
        this.fileRepository = fileRepository;
        this.fileSystem = fileSystem;
    }

    public async Task<Domain.Entities.File> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var formFile = request.FormFile;
        var adapter = fileSystem.GetAdapter(IFileSystem.RisksPrefix);
        var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
        var uploadsPath = $"{IFileSystem.RisksPrefix}://{DateTime.UtcNow:yyyy-MM}";
        var filePath = $"{uploadsPath}/{fileName}";

        if (!fileSystem.DirectoryExists(uploadsPath)) fileSystem.CreateDirectory(uploadsPath);

        await using var stream = new FileStream($"{adapter.RootPath}/{DateTime.UtcNow:yyyy-MM}/{fileName}", FileMode.Create);
        await formFile.CopyToAsync(stream, cancellationToken);

        var file = new Domain.Entities.File
        {
            Name = request.FileName,
            OriginalName = formFile.FileName,
            FileTypeId = request.FileTypeId,
            Path = filePath
        };

        fileRepository.Add(file);
        await fileRepository.SaveChangesAsync(cancellationToken);

        return fileRepository.Refresh(file);
    }
}