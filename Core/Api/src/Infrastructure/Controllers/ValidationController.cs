using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nebula.Core.Shared.Validation;

namespace Nebula.Core.Api.Infrastructure.Controllers;

[ApiController]
[Route("validation")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ValidationController : Controller
{
    private readonly IRemoteDataValidator remoteDataValidator;

    public ValidationController(IMediator mediator, IMapper mapper, IRemoteDataValidator remoteDataValidator) : base(mediator, mapper)
    {
        this.remoteDataValidator = remoteDataValidator;
    }

    [HttpGet]
    [Route("unique-permission-system-name/{permissionSystemName}")]
    public async Task<IActionResult> UniquePermissionSystemName(string permissionSystemName)
    {
        if (await remoteDataValidator.UniquePermissionSystemName(permissionSystemName))
        {
            return Ok();
        }

        return Conflict();
    }

    [HttpGet]
    [Route("unique-group-system-name/{groupSystemName}")]
    public async Task<IActionResult> UniqueGroupSystemName(string groupSystemName)
    {
        if (await remoteDataValidator.UniqueGroupSystemName(groupSystemName))
        {
            return Ok();
        }

        return Conflict();
    }
}