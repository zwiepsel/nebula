using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Process;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("process")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class ProcessController : AppBaseController
{
    public ProcessController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<ProcessViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var processes = await Mediator.Send(new GetAllProcessesQuery());
        var processViewModels = Mapper.Map<IList<ProcessViewModel>>(processes);

        return Ok(processViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(ProcessViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var process = await Mediator.Send(new GetProcessByIdQuery(id));

        if (process == null)
        {
            return NotFound();
        }

        var processViewModel = Mapper.Map<ProcessViewModel>(process);

        return Ok(processViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(ProcessViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(ProcessCreateModel processCreateModel)
    {
        var process = await Mediator.Send(new CreateProcessCommand(processCreateModel));
        var processViewModel = Mapper.Map<ProcessViewModel>(process);

        return Ok(processViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(ProcessViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, ProcessUpdateModel processUpdateModel)
    {
        if (id != processUpdateModel.Id) return BadRequest();

        var process = await Mediator.Send(new GetProcessByIdQuery(id));

        if (process == null)
        {
            return NotFound();
        }

        process = await Mediator.Send(new UpdateProcessCommand(process, processUpdateModel));
        var processViewModel = Mapper.Map<ProcessViewModel>(process);

        return Ok(processViewModel);
    }
}