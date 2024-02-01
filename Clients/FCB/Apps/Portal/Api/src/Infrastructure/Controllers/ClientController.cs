using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Client;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Client;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;

[ApiController]
[Route("client")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class ClientController : AppBaseCrudController<Client,
    ClientViewModel,
    ClientCreateModel,
    ClientUpdateModel,
    GetClientByIdQuery,
    GetAllClientsQuery,
    CreateClientCommand,
    UpdateClientCommand>
{
    public ClientController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ClientViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        return await DoGet(id);
    }


    [HttpGet]
    [Route("applicant")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<ClientIndexViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetApplicants()
    {
        var applicants = await Mediator.Send(new GetApplicantsQuery());
        var clientIndexViewModels = new List<ClientIndexViewModel>();

        foreach (var applicant in applicants)
        {
            var clientIndexViewModel = Mapper.Map<ClientIndexViewModel>(applicant);

            clientIndexViewModels.Add(clientIndexViewModel);
        }

        return Ok(clientIndexViewModels);
    }


    [HttpGet]
    [Route("tenant")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<ClientIndexViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTenants()
    {
        var applicants = await Mediator.Send(new GetTenantsQuery());
        var clientIndexViewModels = new List<ClientIndexViewModel>();

        foreach (var applicant in applicants)
        {
            var clientIndexViewModel = Mapper.Map<ClientIndexViewModel>(applicant);

            clientIndexViewModels.Add(clientIndexViewModel);
        }

        return Ok(clientIndexViewModels);
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ClientIndexViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, ClientUpdateModel clientUpdateModel)
    {
        return await DoUpdate(id, clientUpdateModel);
    }
    
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ClientIndexViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(ClientCreateModel clientCreateModel)
    {
        return await DoCreate(clientCreateModel);
    }
}