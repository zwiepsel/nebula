using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.FileType.Handlers;

public class GetFileTypeByIdHandler : IRequestHandler<GetFileTypeByIdQuery, Domain.Entities.FileType?>
{
    private readonly IFileTypeRepository fileTypeRepository;

    public GetFileTypeByIdHandler(IFileTypeRepository fileTypeRepository)
    {
        this.fileTypeRepository = fileTypeRepository;
    }

    public async Task<Domain.Entities.FileType?> Handle(GetFileTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await fileTypeRepository.FindById(request.Id);
    }
}