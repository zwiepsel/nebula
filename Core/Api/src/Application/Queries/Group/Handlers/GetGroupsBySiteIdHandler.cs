using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Group.Handlers;

public class GetGroupsBySiteIdHandler : IRequestHandler<GetGroupsBySiteIdQuery, IList<Domain.Entities.Group>>
{
    private readonly IGroupRepository groupRepository;

    public GetGroupsBySiteIdHandler(IGroupRepository groupRepository)
    {
        this.groupRepository = groupRepository;
    }

    public async Task<IList<Domain.Entities.Group>> Handle(GetGroupsBySiteIdQuery request, CancellationToken cancellationToken)
    {
        return await groupRepository.FindBySiteId(request.SiteId, cancellationToken);
    }
}