using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File.Handlers;

public class GetFileByIdHandler : IRequestHandler<GetFileByIdQuery, Domain.Entities.File?>
{
    private readonly IFileRepository fileRepository;

    public GetFileByIdHandler(IFileRepository fileRepository)
    {
        this.fileRepository = fileRepository;
    }

    public async Task<Domain.Entities.File?> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
        return await fileRepository.FindById(request.Id);
    }
}