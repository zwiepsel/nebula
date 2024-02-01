using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;

public class UpdateMitigationControlHandler : IRequestHandler<UpdateMitigationControlCommand, Domain.Entities.MitigationControl>
{
    private readonly IMapper mapper;
    private readonly IMitigationControlRepository mitigationControlRepository;

    public UpdateMitigationControlHandler(IMitigationControlRepository mitigationControlRepository, IMapper mapper)
    {
        this.mitigationControlRepository = mitigationControlRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.MitigationControl> Handle(UpdateMitigationControlCommand request, CancellationToken cancellationToken)
    {
        var mitigationControl = mapper.Map(request.MitigationControlUpdateModel, request.MitigationControl);

        mitigationControlRepository.Update(mitigationControl);
        await mitigationControlRepository.SaveChangesAsync(cancellationToken);

        return mitigationControl;
    }
}