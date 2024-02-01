using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Site.Handlers;

public class GetSiteByIdHandler : IRequestHandler<GetSiteByIdQuery, Domain.Entities.Site?>
{
    private readonly ISiteRepository siteRepository;

    public GetSiteByIdHandler(ISiteRepository siteRepository)
    {
        this.siteRepository = siteRepository;
    }

    public async Task<Domain.Entities.Site?> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
    {
        return await siteRepository.FindById(request.Id);
    }
}