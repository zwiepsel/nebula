using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.File;
using Nebula.Clients.FCB.Shared.Models.File;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers.Public;

[ApiController]
[Route("public/file")]
public class PublicFileController : AppBaseController
{

    public PublicFileController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {

    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(FileViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromForm] IEnumerable<IFormFile> formFiles, [FromForm] string fileName,
        [FromForm] int fileTypeId)
    {
        var files = formFiles.ToList();

        if (files.Count != 1)
        {
            return BadRequest();
        }

        var file = await Mediator.Send(new CreateFileCommand(files.First(), fileName, fileTypeId));
        var fileViewModel = Mapper.Map<FileViewModel>(file);

        return Ok(fileViewModel);
    }
    
    
}