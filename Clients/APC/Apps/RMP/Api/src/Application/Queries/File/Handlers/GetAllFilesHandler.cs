using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File.Handlers;

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