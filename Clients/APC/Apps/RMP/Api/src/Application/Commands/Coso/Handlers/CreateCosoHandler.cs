using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso.Handlers;

public class CreateCosoHandler : IRequestHandler<CreateCosoCommand, Domain.Entities.Coso>
{
    private readonly ICosoRepository cosoRepository;
    private readonly IMapper mapper;

    public CreateCosoHandler(ICosoRepository cosoRepository, IMapper mapper)
    {
        this.cosoRepository = cosoRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Coso> Handle(CreateCosoCommand request, CancellationToken cancellationToken)
    {
        var coso = mapper.Map<Domain.Entities.Coso>(request.CosoCreateModel);

        cosoRepository.Add(coso);
        await cosoRepository.SaveChangesAsync(cancellationToken);

        return coso;
    }
}