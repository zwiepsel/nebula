using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("firm")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class FirmController : AppBaseController
{
    public FirmController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<FirmViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var firms = await Mediator.Send(new GetAllFirmsQuery());
        var firmViewModels = Mapper.Map<IList<FirmViewModel>>(firms);

        return Ok(firmViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(FirmViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var firm = await Mediator.Send(new GetFirmByIdQuery(id));

        if (firm == null)
        {
            return NotFound();
        }

        var firmViewModel = Mapper.Map<FirmViewModel>(firm);

        return Ok(firmViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(FirmViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(FirmCreateModel firmCreateModel)
    {
        var firm = await Mediator.Send(new CreateFirmCommand(firmCreateModel));
        var firmViewModel = Mapper.Map<FirmViewModel>(firm);

        return Ok(firmViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(FirmViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, FirmUpdateModel firmUpdateModel)
    {
        if (id != firmUpdateModel.Id) return BadRequest();

        var firm = await Mediator.Send(new GetFirmByIdQuery(id));

        if (firm == null) return NotFound();

        firm = await Mediator.Send(new UpdateFirmCommand(firm, firmUpdateModel));
        var firmViewModel = Mapper.Map<FirmViewModel>(firm);

        return Ok(firmViewModel);
    }
}