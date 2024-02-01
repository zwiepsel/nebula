using Nebula.Core.Api.Application.Commands.User.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Api.Application.Commands.User;

/// <see cref="UpdateUserHandler" />
public class UpdateUserCommand : IEntityUpdateCommand<Domain.Entities.Identity.User, UserUpdateModel>
{
    public Domain.Entities.Identity.User Entity { get; set; }
    public UserUpdateModel UpdateModel { get; set; }
    
    public UpdateUserCommand(Domain.Entities.Identity.User user, UserUpdateModel userUpdateModel)
    {
        Entity = user;
        UpdateModel = userUpdateModel;
    }
}