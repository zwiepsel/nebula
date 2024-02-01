using Nebula.Core.Api.Application.Commands.App.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.App;

namespace Nebula.Core.Api.Application.Commands.App;

/// <see cref="CreateAppHandler" />
public class CreateAppCommand : IEntityCreateCommand<Domain.Entities.App, AppCreateModel>
{
    public CreateAppCommand(AppCreateModel appCreateModel)
    {
        CreateModel = appCreateModel;
    }

    public AppCreateModel CreateModel { get; set; }
}