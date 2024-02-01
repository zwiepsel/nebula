using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.SiteUser.Handlers;

public class GetSiteUserByIdHandler : IRequestHandler<GetSiteUserByIdQuery, Domain.Entities.SiteUser?>
{
    private readonly ISiteUserRepository siteUserRepository;

    public GetSiteUserByIdHandler(ISiteUserRepository siteUserRepository)
    {
        this.siteUserRepository = siteUserRepository;
    }

    public async Task<Domain.Entities.SiteUser?> Handle(GetSiteUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await siteUserRepository.FindById(request.Id, cancellationToken);
    }
}