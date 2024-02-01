using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl.Handlers;

public class CreateMitigationControlFileHandler : IRequestHandler<CreateMitigationControlFileCommand, Domain.Entities.MitigationControl>
{
    private readonly IMitigationControlRepository mitigationControlRepository;

    public CreateMitigationControlFileHandler(IMitigationControlRepository mitigationControlRepository)
    {
        this.mitigationControlRepository = mitigationControlRepository;
    }

    public async Task<Domain.Entities.MitigationControl> Handle(CreateMitigationControlFileCommand request,
        CancellationToken cancellationToken)
    {
        var mitigationControl = request.MitigationControl;
        mitigationControl.Files.Add(request.File);

        mitigationControlRepository.Update(mitigationControl);
        await mitigationControlRepository.SaveChangesAsync(cancellationToken);

        return mitigationControl;
    }
}