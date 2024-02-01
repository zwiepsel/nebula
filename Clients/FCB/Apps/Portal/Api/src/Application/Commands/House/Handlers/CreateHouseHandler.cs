using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House.Handlers;

public class CreateHouseHandler : IRequestHandler<CreateHouseCommand, Domain.Entities.House>
{
    private readonly IHouseRepository houseRepository;
    private readonly IMapper mapper;

    public CreateHouseHandler(IHouseRepository houseRepository, IMapper mapper)
    {
        this.houseRepository = houseRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.House> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.House>(request.CreateModel);

        houseRepository.Add(entity);
        await houseRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}