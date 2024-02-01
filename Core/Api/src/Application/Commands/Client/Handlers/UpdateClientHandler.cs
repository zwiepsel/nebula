using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Client.Handlers;

public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Domain.Entities.Client>
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;

    public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = mapper.Map(request.UpdateModel, request.Entity);

        clientRepository.Update(client);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return client;
    }
}