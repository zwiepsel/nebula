using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood.Handlers;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood;

/// <see cref="UpdateNeighborhoodHandler" />
public class UpdateNeighborhoodCommand : IEntityUpdateCommand<Domain.Entities.Neighborhood, NeighborhoodUpdateModel>
{
    public UpdateNeighborhoodCommand(Domain.Entities.Neighborhood entity, NeighborhoodUpdateModel updateModel)
    {
        Entity = entity;
        UpdateModel = updateModel;
    }

    public Domain.Entities.Neighborhood Entity { get; set; }
    public NeighborhoodUpdateModel UpdateModel { get; set; }
}