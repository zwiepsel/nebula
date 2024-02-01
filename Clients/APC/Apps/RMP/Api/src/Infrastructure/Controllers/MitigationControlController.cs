using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("mitigation-control")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class MitigationControlController : AppBaseController
{
    public MitigationControlController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<MitigationControlViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var mitigationControls = await Mediator.Send(new GetAllMitigationControlsQuery());
        var mitigationControlViewModels = Mapper.Map<IList<MitigationControlViewModel>>(mitigationControls);

        return Ok(mitigationControlViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(MitigationControlViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(id));

        if (mitigationControl == null)
        {
            return NotFound();
        }

        var mitigationControlViewModel = Mapper.Map<MitigationControlViewModel>(mitigationControl);

        return Ok(mitigationControlViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(MitigationControlViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(MitigationControlCreateModel mitigationControlCreateModel)
    {
        var mitigationControl = await Mediator.Send(new CreateMitigationControlCommand(mitigationControlCreateModel));
        var mitigationControlViewModel = Mapper.Map<MitigationControlViewModel>(mitigationControl);

        return Ok(mitigationControlViewModel);
    }

    [HttpPost]
    [Route("{id:int}/file/{fileId:int}")]
    [ProducesResponseType(typeof(MitigationControlViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> CreateFile(int id, int fileId)
    {
        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(id));
        var file = await Mediator.Send(new GetFileByIdQuery(fileId));

        if (mitigationControl == null || file == null)
        {
            return NotFound();
        }

        mitigationControl = await Mediator.Send(new CreateMitigationControlFileCommand(mitigationControl, file));
        var mitigationControlViewModel = Mapper.Map<MitigationControlViewModel>(mitigationControl);

        return Ok(mitigationControlViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(MitigationControlViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, MitigationControlUpdateModel mitigationControlUpdateModel)
    {
        if (id != mitigationControlUpdateModel.Id)
        {
            return BadRequest();
        }

        var mitigationControl = await Mediator.Send(new GetMitigationControlByIdQuery(id));

        if (mitigationControl == null)
        {
            return NotFound();
        }

        mitigationControl = await Mediator.Send(new UpdateMitigationControlCommand(mitigationControl, mitigationControlUpdateModel));
        var mitigationControlViewModel = Mapper.Map<MitigationControlViewModel>(mitigationControl);

        return Ok(mitigationControlViewModel);
    }
}