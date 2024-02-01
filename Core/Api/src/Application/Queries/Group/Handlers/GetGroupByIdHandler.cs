using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Queries.Group.Handlers;

public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, Domain.Entities.Group?>
{
    private readonly IGroupRepository groupRepository;

    public GetGroupByIdHandler(IGroupRepository groupRepository)
    {
        this.groupRepository = groupRepository;
    }

    public async Task<Domain.Entities.Group?> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        return await groupRepository.FindById(request.Id, cancellationToken);
    }
}