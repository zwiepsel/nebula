using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;

public class CreateMitigationControlHandler : IRequestHandler<CreateMitigationControlCommand, Domain.Entities.MitigationControl>
{
    private readonly IMapper mapper;
    private readonly IMitigationControlRepository mitigationControlRepository;

    public CreateMitigationControlHandler(IMitigationControlRepository mitigationControlRepository, IMapper mapper)
    {
        this.mitigationControlRepository = mitigationControlRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.MitigationControl> Handle(CreateMitigationControlCommand request, CancellationToken cancellationToken)
    {
        var mitigationControl = mapper.Map<Domain.Entities.MitigationControl>(request.MitigationControlCreateModel);

        mitigationControlRepository.Add(mitigationControl);
        await mitigationControlRepository.SaveChangesAsync(cancellationToken);

        return mitigationControl;
    }
}