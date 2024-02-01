using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House.Handlers;

public class UpdateHouseHandler : IRequestHandler<UpdateHouseCommand, Domain.Entities.House>
{
    private readonly IHouseRepository houseRepository;
    private readonly IMapper mapper;

    public UpdateHouseHandler(IHouseRepository houseRepository, IMapper mapper)
    {
        this.houseRepository = houseRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.House> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map(request.UpdateModel, request.Entity);

        houseRepository.Update(entity);
        await houseRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}