using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.App;
using Nebula.Core.Api.Application.Queries.App;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Constants;
using Nebula.Shared.Models.App;

namespace Nebula.Core.Api.Infrastructure.Controllers.Admin;

[ApiController]
[Route("admin/app")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = CoreRoles.Administrator)]
public class AppController : BaseCrudController<App,
    AppViewModel,
    AppCreateModel,
    AppUpdateModel,
    GetAppByIdQuery,
    GetAllAppsQuery,
    CreateAppCommand,
    UpdateAppCommand>
{
    public AppController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<AppViewModel>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(AppViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(AppCreateModel appCreateModel)
    {
        return await DoCreate(appCreateModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(AppViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, AppUpdateModel appUpdateModel)
    {
        return await DoUpdate(id, appUpdateModel);
    }
}