using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Api.Application.Queries.Site;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Models.Site;

namespace Nebula.Core.Api.Infrastructure.Controllers;

[ApiController]
[Route("site")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SiteController : Controller
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
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Get()
    {
        var sites = await Mediator.Send(new GetAllSitesQuery());
        var siteViewModels = Mapper.Map<IList<SiteViewModel>>(sites);

        return Ok(siteViewModels);
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("{host}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<SiteViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByHost(string host)
    {
        Site? site;

        if (host == "core")
        {
            site = await Mediator.Send(new GetCoreSiteQuery());
        }
        else
        {
            site = await Mediator.Send(new GetSiteByHostQuery(host));
        }

        if (site == null)
        {
            return NotFound();
        }

        var siteViewModel = Mapper.Map<SiteViewModel>(site);

        return Ok(siteViewModel);
    }
}