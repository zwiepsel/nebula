using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood.Handlers;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood;

/// <see cref="CreateNeighborhoodHandler" />
public class CreateNeighborhoodCommand : IEntityCreateCommand<Domain.Entities.Neighborhood, NeighborhoodCreateModel>
{
    public CreateNeighborhoodCommand(NeighborhoodCreateModel createModel)
    {
        CreateModel = createModel;
    }

    public NeighborhoodCreateModel CreateModel { get; set; }
}