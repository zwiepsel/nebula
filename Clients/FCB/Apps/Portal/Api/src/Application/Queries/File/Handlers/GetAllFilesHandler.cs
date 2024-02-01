using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File.Handlers;

public class GetAllFilesHandler : IRequestHandler<GetAllFilesQuery, IList<Domain.Entities.File>>
{
    private readonly IFileRepository fileRepository;

    public GetAllFilesHandler(IFileRepository fileRepository)
    {
        this.fileRepository = fileRepository;
    }

    public async Task<IList<Domain.Entities.File>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
    {
        return await fileRepository.FindAll(false, cancellationToken);
    }
}