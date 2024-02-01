using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("risk-mitigation-control")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class RiskMitigationControlController : AppBaseController
{
    public RiskMitigationControlController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskMitigationControlViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(int id, RiskMitigationControlUpdateModel riskMitigationControlUpdateModel)
    {
        if (id != riskMitigationControlUpdateModel.Id)
        {
            return BadRequest();
        }

        var riskMitigationControl = await Mediator.Send(new GetRiskMitigationControlByIdQuery(id));

        if (riskMitigationControl == null)
        {
            return NotFound();
        }

        riskMitigationControl =
            await Mediator.Send(new UpdateRiskMitigationControlCommand(riskMitigationControl, riskMitigationControlUpdateModel));
        var riskMitigationControlViewModel = Mapper.Map<RiskMitigationControlViewModel>(riskMitigationControl);

        return Ok(riskMitigationControlViewModel);
    }
}