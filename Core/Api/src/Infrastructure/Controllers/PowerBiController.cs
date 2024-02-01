using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Nebula.Core.Api.Domain.PowerBi;
using Nebula.Core.Api.Domain.Settings;

namespace Nebula.Core.Api.Infrastructure.Controllers;

[ApiController]
[Route("power-bi")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PowerBiController : Controller
{
    private readonly PowerBiEmbedManager powerBiEmbedManager;
    private readonly PowerBiSettings powerBiSettings;

    public PowerBiController(IMediator mediator, IMapper mapper, PowerBiEmbedManager powerBiEmbedManager, PowerBiSettings powerBiSettings)
        : base(mediator, mapper)
    {
        this.powerBiEmbedManager = powerBiEmbedManager;
        this.powerBiSettings = powerBiSettings;
    }

    [HttpGet]
    [Route("embed/report/{reportId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> EmbedReport(string reportId)
    {
        var workspaceId = new Guid(powerBiSettings.WorkspaceId);

        try
        {
            var embedParameters = await powerBiEmbedManager.GetReportEmbedParameters(workspaceId, new Guid(reportId));

            return Ok(embedParameters);
        }
        catch (HttpOperationException httpOperationException) when (httpOperationException.Response.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("embed/dashboard/{dashboardId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> EmbedDashboard(string dashboardId)
    {
        var workspaceId = new Guid(powerBiSettings.WorkspaceId);

        try
        {
            var embedParameters = await powerBiEmbedManager.GetDashboardEmbedParameters(workspaceId, new Guid(dashboardId));

            return Ok(embedParameters);
        }
        catch (HttpOperationException httpOperationException) when (httpOperationException.Response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return Unauthorized();
        }
        catch (HttpOperationException httpOperationException) when (httpOperationException.Response.StatusCode == HttpStatusCode.Forbidden)
        {
            return Unauthorized();
        }
        catch (HttpOperationException httpOperationException) when (httpOperationException.Response.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
    }
}