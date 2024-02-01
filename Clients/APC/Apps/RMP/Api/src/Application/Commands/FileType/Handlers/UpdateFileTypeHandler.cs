using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.FileType.Handlers;

public class UpdateFileTypeHandler : IRequestHandler<UpdateFileTypeCommand, Domain.Entities.FileType>
{
    private readonly IFileTypeRepository fileTypeRepository;
    private readonly IMapper mapper;

    public UpdateFileTypeHandler(IFileTypeRepository fileTypeRepository, IMapper mapper)
    {
        this.fileTypeRepository = fileTypeRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.FileType> Handle(UpdateFileTypeCommand request, CancellationToken cancellationToken)
    {
        var fileType = mapper.Map(request.FileTypeUpdateModel, request.FileType);

        fileTypeRepository.Update(fileType);
        await fileTypeRepository.SaveChangesAsync(cancellationToken);

        return fileType;
    }
}