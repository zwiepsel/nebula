using Nebula.Core.Api.Application.Commands.App.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.App;

namespace Nebula.Core.Api.Application.Commands.App;

/// <see cref="UpdateAppHandler" />
public class UpdateAppCommand : IEntityUpdateCommand<Domain.Entities.App, AppUpdateModel>
{
    public UpdateAppCommand(Domain.Entities.App app, AppUpdateModel appUpdateModel)
    {
        Entity = app;
        UpdateModel = appUpdateModel;
    }

    public Domain.Entities.App Entity { get; set; }
    public AppUpdateModel UpdateModel { get; set; }
}