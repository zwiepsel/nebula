using MediatR;
using Nebula.Core.Api.Application.Commands.Group.Handlers;
using Nebula.Shared.Models.Group;

namespace Nebula.Core.Api.Application.Commands.Group;

/// <see cref="CreateGroupHandler" />
public class CreateGroupCommand : IRequest<Domain.Entities.Group>
{
    public Domain.Entities.Site Site { get; }
    public GroupCreateModel? GroupCreateModel { get; }

    public CreateGroupCommand(Domain.Entities.Site site, GroupCreateModel groupCreateModel)
    {
        Site = site;
        GroupCreateModel = groupCreateModel;
    }
}