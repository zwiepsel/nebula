using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client.Handlers;


public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Domain.Entities.Client>
{
    private readonly IMapper mapper;
    private readonly IClientRepository clientRepository;

    public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map(request.UpdateModel, request.Entity);

        clientRepository.Update(entity);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}