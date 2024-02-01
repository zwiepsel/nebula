using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Site.Handlers;

public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, Domain.Entities.Site>
{
    private readonly IMapper mapper;
    private readonly ISiteRepository siteRepository;

    public CreateSiteHandler(ISiteRepository siteRepository, IMapper mapper)
    {
        this.siteRepository = siteRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Site> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
    {
        var site = mapper.Map<Domain.Entities.Site>(request.CreateModel);

        siteRepository.Add(site);
        await siteRepository.SaveChangesAsync(cancellationToken);

        return site;
    }
}