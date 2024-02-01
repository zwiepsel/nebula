using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process.Handlers;

public class CreateProcessHandler : IRequestHandler<CreateProcessCommand, Domain.Entities.Process>
{
    private readonly IMapper mapper;
    private readonly IProcessRepository processRepository;

    public CreateProcessHandler(IProcessRepository processRepository, IMapper mapper)
    {
        this.processRepository = processRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Process> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
    {
        var process = mapper.Map<Domain.Entities.Process>(request.ProcessCreateModel);

        processRepository.Add(process);
        await processRepository.SaveChangesAsync(cancellationToken);

        return process;
    }
}