using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.App.Handlers;

public class UpdateAppHandler : IRequestHandler<UpdateAppCommand, Domain.Entities.App>
{
    private readonly IAppRepository appRepository;
    private readonly IMapper mapper;

    public UpdateAppHandler(IAppRepository appRepository, IMapper mapper)
    {
        this.appRepository = appRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.App> Handle(UpdateAppCommand request, CancellationToken cancellationToken)
    {
        var app = mapper.Map(request.UpdateModel, request.Entity);

        appRepository.Update(app);
        await appRepository.SaveChangesAsync(cancellationToken);

        return app;
    }
}