using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Group.Handlers;

public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, Domain.Entities.Group>
{
    private readonly IGroupRepository groupRepository;
    private readonly IMapper mapper;

    public CreateGroupHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        this.groupRepository = groupRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Group> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = mapper.Map<Domain.Entities.Group>(request.GroupCreateModel);

        group.SiteId = request.Site.Id;

        groupRepository.Add(group);
        await groupRepository.SaveChangesAsync(cancellationToken);

        return groupRepository.Refresh(group);
    }
}