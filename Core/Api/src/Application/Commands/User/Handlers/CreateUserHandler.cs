using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Domain.Entities.Identity;

namespace Nebula.Core.Api.Application.Commands.User.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Domain.Entities.Identity.User>
{
    private readonly IMapper mapper;
    private readonly UserManager<Domain.Entities.Identity.User> userManager;
    private readonly RoleManager<Role> roleManager;

    public CreateUserHandler(UserManager<Domain.Entities.Identity.User> userManager, RoleManager<Role> roleManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Identity.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userCreateModel = request.CreateModel;

        var role = await roleManager.FindByIdAsync(userCreateModel.RoleId.ToString());

        if (role == null)
        {
            throw new InvalidOperationException();
        }

        var user = mapper.Map<Domain.Entities.Identity.User>(userCreateModel);

        user.UserName = userCreateModel.EmailAddress;
        user.Email = userCreateModel.EmailAddress;
        user.EmailConfirmed = true;

        IdentityResult identityResult;

        if (userCreateModel.Password != null && userCreateModel.ConfirmationPassword != null)
        {
            identityResult = await userManager.CreateAsync(user, userCreateModel.Password);
        }
        else
        {
            identityResult = await userManager.CreateAsync(user);
        }

        if (!identityResult.Succeeded)
        {
            throw new InvalidOperationException();
        }

        await userManager.AddToRoleAsync(user, role.NormalizedName);

        return user;
    }
}