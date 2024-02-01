using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("coso")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class CosoController : AppBaseController
{
    public CosoController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<CosoViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var cosos = await Mediator.Send(new GetAllCososQuery());
        var cosoViewModels = Mapper.Map<IList<CosoViewModel>>(cosos);

        return Ok(cosoViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(CosoViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Get(int id)
    {
        var coso = await Mediator.Send(new GetCosoByIdQuery(id));

        if (coso == null)
        {
            return NotFound();
        }

        var cosoViewModel = Mapper.Map<CosoViewModel>(coso);

        return Ok(cosoViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(CosoViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(CosoCreateModel cosoCreateModel)
    {
        var coso = await Mediator.Send(new CreateCosoCommand(cosoCreateModel));
        var cosoViewModel = Mapper.Map<CosoViewModel>(coso);

        return Ok(cosoViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(CosoViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, CosoUpdateModel cosoUpdateModel)
    {
        if (id != cosoUpdateModel.Id)
        {
            return BadRequest();
        }

        var coso = await Mediator.Send(new GetCosoByIdQuery(id));

        if (coso == null)
        {
            return NotFound();
        }

        coso = await Mediator.Send(new UpdateCosoCommand(coso, cosoUpdateModel));
        var cosoViewModel = Mapper.Map<CosoViewModel>(coso);

        return Ok(cosoViewModel);
    }
}