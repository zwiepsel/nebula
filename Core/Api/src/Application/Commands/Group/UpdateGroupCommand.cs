using MediatR;
using Nebula.Core.Api.Application.Commands.Group.Handlers;
using Nebula.Shared.Models.Group;

namespace Nebula.Core.Api.Application.Commands.Group;

/// <see cref="UpdateGroupHandler" />
public class UpdateGroupCommand : IRequest<Domain.Entities.Group>
{
    public Domain.Entities.Group Group { get; }
    public GroupUpdateModel GroupUpdateModel { get; }

    public UpdateGroupCommand(Domain.Entities.Group group, GroupUpdateModel groupUpdateModel)
    {
        Group = group;
        GroupUpdateModel = groupUpdateModel;
    }
}