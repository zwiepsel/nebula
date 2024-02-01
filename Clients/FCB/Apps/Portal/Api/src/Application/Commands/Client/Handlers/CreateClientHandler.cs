using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client.Handlers;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, Domain.Entities.Client>
{
    private readonly IMapper mapper;
    private readonly IClientRepository clientRepository;

    public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Client>(request.CreateModel);

        clientRepository.Add(entity);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}