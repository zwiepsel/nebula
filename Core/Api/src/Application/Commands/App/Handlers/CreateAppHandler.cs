using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.App.Handlers;

public class CreateAppHandler : IRequestHandler<CreateAppCommand, Domain.Entities.App>
{
    private readonly IAppRepository appRepository;
    private readonly IMapper mapper;

    public CreateAppHandler(IAppRepository appRepository, IMapper mapper)
    {
        this.appRepository = appRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.App> Handle(CreateAppCommand request, CancellationToken cancellationToken)
    {
        var app = mapper.Map<Domain.Entities.App>(request.CreateModel);

        appRepository.Add(app);
        await appRepository.SaveChangesAsync(cancellationToken);

        return app;
    }
}