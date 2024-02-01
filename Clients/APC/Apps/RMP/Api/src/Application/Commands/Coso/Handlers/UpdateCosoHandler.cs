using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso.Handlers;

public class UpdateCosoHandler : IRequestHandler<UpdateCosoCommand, Domain.Entities.Coso>
{
    private readonly ICosoRepository cosoRepository;
    private readonly IMapper mapper;

    public UpdateCosoHandler(ICosoRepository cosoRepository, IMapper mapper)
    {
        this.cosoRepository = cosoRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Coso> Handle(UpdateCosoCommand request, CancellationToken cancellationToken)
    {
        var coso = mapper.Map(request.CosoUpdateModel, request.Coso);

        cosoRepository.Update(coso);
        await cosoRepository.SaveChangesAsync(cancellationToken);

        return coso;
    }
}