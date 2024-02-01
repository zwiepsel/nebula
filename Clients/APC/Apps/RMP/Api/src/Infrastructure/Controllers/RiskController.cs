using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("risk")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class RiskController : AppBaseController
{
    public RiskController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<RiskViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var risks = await Mediator.Send(new GetAllRisksQuery());
        var riskViewModels = Mapper.Map<IList<RiskViewModel>>(risks);

        return Ok(riskViewModels);
    }

    [HttpGet]
    [Route("index")]
    [ProducesResponseType(typeof(IList<RiskIndexViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIndex()
    {
        var risks = await Mediator.Send(new GetAllRisksQuery());
        var riskViewModels = Mapper.Map<IList<RiskIndexViewModel>>(risks);

        return Ok(riskViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));

        if (risk == null)
        {
            return NotFound();
        }

        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(RiskCreateModel riskCreateModel)
    {
        var risk = await Mediator.Send(new CreateRiskCommand(riskCreateModel));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(int id, RiskUpdateModel riskUpdateModel)
    {
        if (id != riskUpdateModel.Id)
        {
            return BadRequest();
        }

        var risk = await Mediator.Send(new GetRiskByIdQuery(id));

        if (risk == null)
        {
            return NotFound();
        }

        risk = await Mediator.Send(new UpdateRiskCommand(risk, riskUpdateModel));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));

        if (risk == null)
        {
            return NotFound();
        }

        await Mediator.Send(new DeleteRiskCommand(risk));

        return Ok();
    }

    [HttpPost]
    [Route("{id:int}/file/{fileId:int}")]
    [ProducesResponseType(typeof(RiskViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateFile(int id, int fileId)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var file = await Mediator.Send(new GetFileByIdQuery(fileId));

        if (risk == null || file == null)
        {
            return NotFound();
        }

        risk = await Mediator.Send(new CreateRiskFileCommand(risk, file));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpPost]
    [Route("{id:int}/department/{departmentId:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateDepartment(int id, int departmentId)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var department = await Mediator.Send(new GetDepartmentByIdQuery(departmentId));

        if (risk == null || department == null)
        {
            return NotFound();
        }

        risk = await Mediator.Send(new CreateRiskDepartmentCommand(risk, department));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpDelete]
    [Route("{id:int}/department/{departmentId:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteDepartment(int id, int departmentId)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var department = await Mediator.Send(new GetDepartmentByIdQuery(departmentId));

        if (risk == null || department == null)
        {
            return NotFound();
        }

        if (risk.Departments.All(d => d.Id != department.Id))
        {
            return BadRequest();
        }

        risk = await Mediator.Send(new DeleteRiskDepartmentCommand(risk, department));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpPost]
    [Route("{id:int}/mitigation-control/{mitigationControlId:int}")]
    [ProducesResponseType(typeof(RiskMitigationControlViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateMitigationControl(int id, int mitigationControlId, MitigationControlLinkModel model)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(mitigationControlId));

        if (risk == null || mitigationControl == null)
        {
            return NotFound();
        }

        var riskMitigationControl = await Mediator.Send(new CreateRiskMitigationControlCommand(risk, mitigationControl, model));
        var riskMitigationControlViewModel = Mapper.Map<RiskMitigationControlViewModel>(riskMitigationControl);

        return Ok(riskMitigationControlViewModel);
    }

    [HttpDelete]
    [Route("{id:int}/mitigation-control/{mitigationControlId:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteMitigationControl(int id, int mitigationControlId)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(mitigationControlId));

        if (risk == null || mitigationControl == null)
        {
            return NotFound();
        }

        if (risk.MitigationControls.All(d => d.Id != mitigationControl.Id))
        {
            return BadRequest();
        }

        risk = await Mediator.Send(new DeleteRiskMitigationControlCommand(risk, mitigationControl));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }

    [HttpPost]
    [Route("{id:int}/possible-optimization/{mitigationControlId:int}")]
    [ProducesResponseType(typeof(RiskPossibleOptimizationViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreatePossibleOptimization(int id, int mitigationControlId, MitigationControlLinkModel model)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(mitigationControlId));

        if (risk == null || mitigationControl == null)
        {
            return NotFound();
        }

        var riskPossibleOptimization = await Mediator.Send(new CreateRiskPossibleOptimizationCommand(risk, mitigationControl, model));
        var riskPossibleOptimizationViewModel = Mapper.Map<RiskPossibleOptimizationViewModel>(riskPossibleOptimization);

        return Ok(riskPossibleOptimizationViewModel);
    }

    [HttpDelete]
    [Route("{id:int}/possible-optimization/{mitigationControlId:int}")]
    [ProducesResponseType(typeof(RiskViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletePossibleOptimization(int id, int mitigationControlId)
    {
        var risk = await Mediator.Send(new GetRiskByIdQuery(id));
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(mitigationControlId));

        if (risk == null || mitigationControl == null)
        {
            return NotFound();
        }

        if (risk.PossibleOptimizations.All(d => d.Id != mitigationControl.Id))
        {
            return BadRequest();
        }

        risk = await Mediator.Send(new DeleteRiskPossibleOptimizationCommand(risk, mitigationControl));
        var riskViewModel = Mapper.Map<RiskViewModel>(risk);

        return Ok(riskViewModel);
    }
}