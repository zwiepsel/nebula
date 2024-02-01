using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType.Handlers;

public class CreateFileTypeHandler : IRequestHandler<CreateFileTypeCommand, Domain.Entities.FileType>
{
    private readonly IFileTypeRepository fileTypeRepository;
    private readonly IMapper mapper;

    public CreateFileTypeHandler(IFileTypeRepository fileTypeRepository, IMapper mapper)
    {
        this.fileTypeRepository = fileTypeRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.FileType> Handle(CreateFileTypeCommand request, CancellationToken cancellationToken)
    {
        var fileType = mapper.Map<Domain.Entities.FileType>(request.FileTypeCreateModel);

        fileTypeRepository.Add(fileType);
        await fileTypeRepository.SaveChangesAsync(cancellationToken);

        return fileType;
    }
}