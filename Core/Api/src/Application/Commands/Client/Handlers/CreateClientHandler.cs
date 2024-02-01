using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Client.Handlers;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, Domain.Entities.Client>
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;

    public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = mapper.Map<Domain.Entities.Client>(request.CreateModel);

        clientRepository.Add(client);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return client;
    }
}