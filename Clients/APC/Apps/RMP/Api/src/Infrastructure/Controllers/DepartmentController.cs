using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Department;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("department")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class DepartmentController : AppBaseController
{
    public DepartmentController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<DepartmentViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var departments = await Mediator.Send(new GetAllDepartmentsQuery());
        var departmentViewModels = Mapper.Map<IList<DepartmentViewModel>>(departments);

        return Ok(departmentViewModels);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(DepartmentViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var department = await Mediator.Send(new GetDepartmentByIdQuery(id));

        if (department == null) return NotFound();

        var departmentViewModel = Mapper.Map<DepartmentViewModel>(department);

        return Ok(departmentViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(DepartmentViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(DepartmentCreateModel departmentCreateModel)
    {
        var department = await Mediator.Send(new CreateDepartmentCommand(departmentCreateModel));
        var departmentViewModel = Mapper.Map<DepartmentViewModel>(department);

        return Ok(departmentViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(DepartmentViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, DepartmentUpdateModel departmentUpdateModel)
    {
        if (id != departmentUpdateModel.Id) return BadRequest();

        var department = await Mediator.Send(new GetDepartmentByIdQuery(id));

        if (department == null) return NotFound();

        department = await Mediator.Send(new UpdateDepartmentCommand(department, departmentUpdateModel));
        var departmentViewModel = Mapper.Map<DepartmentViewModel>(department);

        return Ok(departmentViewModel);
    }
}