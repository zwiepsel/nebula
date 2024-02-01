using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType.Handlers;

public class GetAllFileTypesHandler : IRequestHandler<GetAllFileTypesQuery, IEnumerable<Domain.Entities.FileType>>
{
    private readonly IFileTypeRepository fileTypeRepository;

    public GetAllFileTypesHandler(IFileTypeRepository fileTypeRepository)
    {
        this.fileTypeRepository = fileTypeRepository;
    }

    public async Task<IEnumerable<Domain.Entities.FileType>> Handle(GetAllFileTypesQuery request, CancellationToken cancellationToken)
    {
        return await fileTypeRepository.FindAll(false, cancellationToken);
    }
}