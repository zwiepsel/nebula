using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("risk-possible-optimization")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class RiskPossibleOptimizationController : AppBaseController
{
    public RiskPossibleOptimizationController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskPossibleOptimizationViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(int id, RiskPossibleOptimizationUpdateModel riskPossibleOptimizationUpdateModel)
    {
        if (id != riskPossibleOptimizationUpdateModel.Id) return BadRequest();

        var riskPossibleOptimization = await Mediator.Send(new GetRiskPossibleOptimizationByIdQuery(id));

        if (riskPossibleOptimization == null) return NotFound();

        riskPossibleOptimization =
            await Mediator.Send(new UpdateRiskPossibleOptimizationCommand(riskPossibleOptimization, riskPossibleOptimizationUpdateModel));
        var riskPossibleOptimizationViewModel = Mapper.Map<RiskPossibleOptimizationViewModel>(riskPossibleOptimization);

        return Ok(riskPossibleOptimizationViewModel);
    }
}