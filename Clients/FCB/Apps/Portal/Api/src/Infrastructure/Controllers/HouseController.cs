using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.House;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.House;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;

[ApiController]
[Route("house")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class HouseController : AppBaseCrudController<House,
    HouseViewModel,
    HouseCreateModel,
    HouseUpdateModel,
    GetHouseByIdQuery,
    GetAllHousesQuery,
    CreateHouseCommand,
    UpdateHouseCommand>
{
    public HouseController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(HouseViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        return await DoGet(id);
    }

    [HttpGet]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<HouseViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
       // var currentUser = await GetCurrentUser();
        
        return await DoGet();
    }

    [HttpGet]
    [Route("index")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<HouseIndexViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetIndex()
    {
        var houses = await Mediator.Send(new GetAllHousesQuery());
        var houseIndexViewModels = new List<HouseIndexViewModel>();

        foreach (var house in houses)
        {
            var houseIndexViewModel = Mapper.Map<HouseIndexViewModel>(house);
            var leaseAgreement = house.LeaseAgreements.FirstOrDefault(la => la.EndDate > DateTime.UtcNow || la.EndDate == null);

            houseIndexViewModel.Rented = house.LeaseAgreements.Any(la => la.EndDate > DateTime.UtcNow  || la.EndDate == null);
            houseIndexViewModel.NeighborhoodName = house.Neighborhood.Name;
            houseIndexViewModel.ComplexName = house.Complex.Name;
            houseIndexViewModel.TenantFullName = leaseAgreement?.Client.Name;
            houseIndexViewModel.RentAmount = leaseAgreement?.Rents.OrderByDescending(r => r.CreatedAt).First().AskPrice;

            houseIndexViewModels.Add(houseIndexViewModel);
        }

        return Ok(houseIndexViewModels);
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(HouseIndexViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, HouseUpdateModel houseUpdateModel)
    {
        return await DoUpdate(id, houseUpdateModel);
    }
}