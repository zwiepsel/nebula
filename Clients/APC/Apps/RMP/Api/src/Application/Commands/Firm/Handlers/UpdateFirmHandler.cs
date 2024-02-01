using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm.Handlers;

public class UpdateFirmHandler : IRequestHandler<UpdateFirmCommand, Domain.Entities.Firm>
{
    private readonly IFirmRepository firmRepository;
    private readonly IMapper mapper;

    public UpdateFirmHandler(IFirmRepository firmRepository, IMapper mapper)
    {
        this.firmRepository = firmRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Firm> Handle(UpdateFirmCommand request, CancellationToken cancellationToken)
    {
        var firm = mapper.Map(request.FirmUpdateModel, request.Firm);

        firmRepository.Update(firm);
        await firmRepository.SaveChangesAsync(cancellationToken);

        return firm;
    }
}