using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Neighborhood;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Neighborhood;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;

[ApiController]
[Route("neighborhood")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class NeighborhoodController : AppBaseCrudController<Neighborhood,
    NeighborhoodViewModel,
    NeighborhoodCreateModel,
    NeighborhoodUpdateModel,
    GetNeighborhoodByIdQuery,
    GetAllNeighborhoodsQuery,
    CreateNeighborhoodCommand,
    UpdateNeighborhoodCommand>
{
    public NeighborhoodController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(NeighborhoodViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        return await DoGet(id);
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<NeighborhoodViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return await DoGet();
    }
}