using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.IncomeScale;
using Nebula.Clients.FCB.Shared.Models.IncomeScale;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers.Public;

[ApiController]
[Route("public/incomeScale")]
public class PublicIncomeScaleController : AppBaseController
{
    public PublicIncomeScaleController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<IncomeScaleViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublic()
    {
        var incomeScales = await Mediator.Send(new GetIncomeScaleQuery());
        var incomeScalesViewModels = Mapper.Map<IList<IncomeScaleViewModel>>(incomeScales);

        return Ok(incomeScalesViewModels);
    }
}