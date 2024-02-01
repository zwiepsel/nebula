using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Commands.Site;
using Nebula.Core.Api.Application.Queries.Site;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Constants;
using Nebula.Shared.Models.Site;

namespace Nebula.Core.Api.Infrastructure.Controllers.Admin;

[ApiController]
[Route("admin/site")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = CoreRoles.Administrator)]
public class SiteController : BaseCrudController<Site,
    SiteViewModel,
    SiteCreateModel,
    SiteUpdateModel,
    GetSiteByIdQuery,
    GetAllSitesQuery,
    CreateSiteCommand,
    UpdateSiteCommand>
{
    public SiteController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<SiteViewModel>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(SiteViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(SiteCreateModel siteCreateModel)
    {
        return await DoCreate(siteCreateModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SiteViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, SiteUpdateModel siteUpdateModel)
    {
        return await DoUpdate(id, siteUpdateModel);
    }
}