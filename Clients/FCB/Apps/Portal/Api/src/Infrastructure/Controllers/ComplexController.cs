using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Complex;
using Nebula.Clients.FCB.Shared.Models.Complex;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;
[ApiController]
[Route("complex")]
public class ComplexController : BaseController
{

    // GET
    public ComplexController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<ComplexViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var complexes = await Mediator.Send(new GetAllComplexesQuery());
        var complexViewModels = Mapper.Map<IList<ComplexViewModel>>(complexes);

        return Ok(complexViewModels);
    }
}