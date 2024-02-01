using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process.Handlers;

public class UpdateProcessHandler : IRequestHandler<UpdateProcessCommand, Domain.Entities.Process>
{
    private readonly IMapper mapper;
    private readonly IProcessRepository processRepository;

    public UpdateProcessHandler(IProcessRepository processRepository, IMapper mapper)
    {
        this.processRepository = processRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Process> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
    {
        var process = mapper.Map(request.ProcessUpdateModel, request.Process);

        processRepository.Update(process);
        await processRepository.SaveChangesAsync(cancellationToken);

        return process;
    }
}