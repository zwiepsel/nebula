using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Application.Commands.Group.Handlers;

public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, Domain.Entities.Group>
{
    private readonly IGroupRepository groupRepository;
    private readonly IMapper mapper;

    public UpdateGroupHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        this.groupRepository = groupRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Group> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = mapper.Map(request.GroupUpdateModel, request.Group);

        groupRepository.Update(group);
        await groupRepository.SaveChangesAsync(cancellationToken);

        return group;
    }
}