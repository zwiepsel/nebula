using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.User;
using Nebula.Core.Api.Application.Queries.User;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Constants;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Api.Infrastructure.Controllers.Admin;

[ApiController]
[Route("admin/user")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = CoreRoles.Administrator)]
public class UserController : BaseCrudController<User,
    UserViewModel,
    UserCreateModel,
    UserUpdateModel,
    GetUserByIdQuery,
    GetAllUsersQuery,
    CreateUserCommand,
    UpdateUserCommand>
{
    public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<UserViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Get()
    {
        return await DoGet();
    }

    [HttpPost]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(UserCreateModel userCreateModel)
    {
        return await DoCreate(userCreateModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UserUpdateModel userUpdateModel)
    {
        return await DoUpdate(id, userUpdateModel);
    }
}