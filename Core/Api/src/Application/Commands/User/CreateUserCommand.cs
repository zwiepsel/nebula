using Nebula.Core.Api.Application.Commands.User.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Api.Application.Commands.User;

/// <see cref="CreateUserHandler" />
public class CreateUserCommand : IEntityCreateCommand<Domain.Entities.Identity.User, UserCreateModel>
{
    public UserCreateModel CreateModel { get; set; }

    public CreateUserCommand(UserCreateModel userCreateModel)
    {
        CreateModel = userCreateModel;
    }
}