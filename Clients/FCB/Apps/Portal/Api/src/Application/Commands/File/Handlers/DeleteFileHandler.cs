using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.File.Handlers;

public class DeleteFileHandler : AsyncRequestHandler<DeleteFileCommand>
{
    private readonly IFileRepository fileRepository;

    public DeleteFileHandler(IFileRepository fileRepository)
    {
        this.fileRepository = fileRepository;
    }

    protected override async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        fileRepository.Delete(request.File);
        await fileRepository.SaveChangesAsync(cancellationToken);
    }
}