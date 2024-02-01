using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.AgeScale;
using Nebula.Clients.FCB.Shared.Models.AgeScale;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers.Public;

[ApiController]
[Route("public/ageScale")]
public class PublicAgeScaleController : AppBaseController
{
    public PublicAgeScaleController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<AgeScaleViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublic()
    {
        var ageScales = await Mediator.Send(new GetAgeScaleQuery());
        var ageScaleViewModels = Mapper.Map<IList<AgeScaleViewModel>>(ageScales);

        return Ok(ageScaleViewModels);
    }
}