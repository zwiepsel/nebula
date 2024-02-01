using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Domain.Entities.Identity;

namespace Nebula.Core.Api.Application.Commands.User.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Domain.Entities.Identity.User>
{
    private readonly IMapper mapper;
    private readonly UserManager<Domain.Entities.Identity.User> userManager;
    private readonly RoleManager<Role> roleManager;

    public UpdateUserHandler(UserManager<Domain.Entities.Identity.User> userManager, RoleManager<Role> roleManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Identity.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userUpdateModel = request.UpdateModel;

        var role = await roleManager.FindByIdAsync(userUpdateModel.RoleId.ToString());

        if (role == null)
        {
            throw new InvalidOperationException();
        }

        var user = mapper.Map(userUpdateModel, request.Entity);

        if (userUpdateModel.Password != null && userUpdateModel.ConfirmationPassword != null)
        {
            await userManager.RemovePasswordAsync(user);
            await userManager.AddPasswordAsync(user, userUpdateModel.Password);
        }

        var currentRoleNames = await userManager.GetRolesAsync(user);
        var currentRole = await roleManager.FindByNameAsync(currentRoleNames.First());

        if (role.Id != currentRole.Id)
        {
            await userManager.RemoveFromRoleAsync(user, currentRole.NormalizedName);
            await userManager.AddToRoleAsync(user, role.NormalizedName);
        }

        await userManager.UpdateAsync(user);

        return user;
    }
}