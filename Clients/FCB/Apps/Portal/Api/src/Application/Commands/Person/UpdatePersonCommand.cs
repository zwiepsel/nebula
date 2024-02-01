using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;

/// <see cref="UpdatePersonHandler" />
public class UpdatePersonCommand : IEntityUpdateCommand<Domain.Entities.Person, PersonUpdateModel>
{
    public UpdatePersonCommand(Domain.Entities.Person entity, PersonUpdateModel updateModel)
    {
        Entity = entity;
        UpdateModel = updateModel;
    }

    public Domain.Entities.Person Entity { get; set; }
    public PersonUpdateModel UpdateModel { get; set; }
}