using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Api.Commands;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;

/// <see cref="CreatePersonHandler" />
public class CreatePersonCommand : IEntityCreateCommand<Domain.Entities.Person, PersonCreateModel>
{
    public CreatePersonCommand(PersonCreateModel createModel)
    {
        CreateModel = createModel;
    }

    public PersonCreateModel CreateModel { get; set; }
}