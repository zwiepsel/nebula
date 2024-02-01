using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Group.Handlers;

public class GetGroupBySiteIdAndSystemNameHandler : IRequestHandler<GetGroupBySiteIdAndSystemNameQuery, Domain.Entities.Group?>
{
    private readonly IGroupRepository groupRepository;

    public GetGroupBySiteIdAndSystemNameHandler(IGroupRepository groupRepository)
    {
        this.groupRepository = groupRepository;
    }

    public async Task<Domain.Entities.Group?> Handle(GetGroupBySiteIdAndSystemNameQuery request, CancellationToken cancellationToken)
    {
        return await groupRepository.FindBySiteIdAndSystemName(request.SiteId, request.SystemName, cancellationToken);
    }
}