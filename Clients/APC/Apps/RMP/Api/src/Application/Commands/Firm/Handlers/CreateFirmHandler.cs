using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm.Handlers;

public class CreateFirmHandler : IRequestHandler<CreateFirmCommand, Domain.Entities.Firm>
{
    private readonly IFirmRepository firmRepository;
    private readonly IMapper mapper;

    public CreateFirmHandler(IFirmRepository firmRepository, IMapper mapper)
    {
        this.firmRepository = firmRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Firm> Handle(CreateFirmCommand request, CancellationToken cancellationToken)
    {
        var firm = mapper.Map<Domain.Entities.Firm>(request.FirmCreateModel);

        firmRepository.Add(firm);
        await firmRepository.SaveChangesAsync(cancellationToken);

        return firm;
    }
}