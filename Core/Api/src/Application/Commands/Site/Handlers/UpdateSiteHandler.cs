using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Site.Handlers;

public class UpdateSiteHandler : IRequestHandler<UpdateSiteCommand, Domain.Entities.Site>
{
    private readonly IMapper mapper;
    private readonly ISiteRepository siteRepository;

    public UpdateSiteHandler(ISiteRepository siteRepository, IMapper mapper)
    {
        this.siteRepository = siteRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Site> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
    {
        var site = mapper.Map(request.UpdateModel, request.Entity);

        siteRepository.Update(site);
        await siteRepository.SaveChangesAsync(cancellationToken);

        return site;
    }
}