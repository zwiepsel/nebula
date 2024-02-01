using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers.Public;

[ApiController]
[Route("public/file-type")]
public class PublicFileTypeController : AppBaseController
{
    public PublicFileTypeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        
    }
    
        
    [AllowAnonymous]
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<FileTypeViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublic()
    {
        var fileTypes = await Mediator.Send(new GetAllFileTypesQuery());
        var fileTypeViewModels = Mapper.Map<IList<FileTypeViewModel>>(fileTypes);

        return Ok(fileTypeViewModels);
    }
}