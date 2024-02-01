using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Person;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.OnboardingState;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;

[ApiController]
[Route("person")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class PersonController : AppBaseCrudController<Person,
    PersonViewModel,
    PersonCreateModel,
    PersonUpdateModel,
    GetPersonByIdQuery,
    GetAllPersonsQuery,
    CreatePersonCommand,
    UpdatePersonCommand>
{
    public PersonController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(IList<PersonViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return await DoGet();
    }
    
    [HttpPost]
    [Route("")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<PersonViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Add(PersonCreateModel personCreateModel)
    {
        var person =  await DoCreate(personCreateModel);
        await Mediator.Send(new CalculateFieldsCommand(personCreateModel.ClientId));
        
        return person;
    }
    
    [HttpPost]
    [Route("createPersons")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddPersons(OnBoardingFamilyModel onBoardingFamilyModel)
    {
        var personsToAdd = new List<Person>();
        foreach (var person in onBoardingFamilyModel.Adults)
        {
            if (person.FirstName == onBoardingFamilyModel.MainContact.FirstName && person.LastName == onBoardingFamilyModel.MainContact.LastName)
            {
                person.MainContact = true;
            }
            person.RelationType = RelationType.Family;
            person.ClientId = onBoardingFamilyModel.ClientId;
            var personCreateModel = Mapper.Map<Person>(person);
            personsToAdd.Add(personCreateModel);
        }
        foreach (var person in onBoardingFamilyModel.Children)
        {
            person.RelationType = RelationType.Family;
            person.ClientId = onBoardingFamilyModel.ClientId;
            var personCreateModel = Mapper.Map<Person>(person);
            personsToAdd.Add(personCreateModel);
        }
        await Mediator.Send(new CreatePersonsFromFamilyCommand(personsToAdd));
        return Ok();
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, PersonUpdateModel personUpdateModel)
    { 
        var person = await DoUpdate(id, personUpdateModel);
        var personModel = (PersonViewModel)((OkObjectResult) person).Value!;
        await Mediator.Send(new CalculateFieldsCommand(personModel.Client.Id));
        var personViewModel = Mapper.Map<PersonViewModel>(personModel);
        
        return Ok(personViewModel); 
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await Mediator.Send(new GetPersonByIdQuery(id));

        if (person == null)
        {
            return NotFound();
        }

        await Mediator.Send(new DeletePersonCommand(person));

        return Ok();
    }
}