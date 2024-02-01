using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskScore;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskScore;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("risk-score")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class RiskScoreController : AppBaseController
{
    public RiskScoreController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<RiskScoreViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var riskScores = await Mediator.Send(new GetAllRiskScoresQuery());
        var riskScoreViewModels = Mapper.Map<IList<RiskScoreViewModel>>(riskScores);

        return Ok(riskScoreViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskScoreViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var riskScore = await Mediator.Send(new GetRiskScoreByIdQuery(id));

        if (riskScore == null)
        {
            return NotFound();
        }

        var riskScoreViewModel = Mapper.Map<RiskScoreViewModel>(riskScore);

        return Ok(riskScoreViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(RiskScoreViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(RiskScoreCreateModel riskScoreCreateModel)
    {
        var riskScore = await Mediator.Send(new CreateRiskScoreCommand(riskScoreCreateModel));
        var riskScoreViewModel = Mapper.Map<RiskScoreViewModel>(riskScore);

        return Ok(riskScoreViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskScoreViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, RiskScoreUpdateModel riskScoreUpdateModel)
    {
        if (id != riskScoreUpdateModel.Id)
        {
            return BadRequest();
        }

        var riskScore = await Mediator.Send(new GetRiskScoreByIdQuery(id));

        if (riskScore == null)
        {
            return NotFound();
        }

        riskScore = await Mediator.Send(new UpdateRiskScoreCommand(riskScore, riskScoreUpdateModel));
        var riskScoreViewModel = Mapper.Map<RiskScoreViewModel>(riskScore);

        return Ok(riskScoreViewModel);
    }
}