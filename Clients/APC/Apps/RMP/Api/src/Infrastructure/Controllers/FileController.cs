using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.File;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.FileSystem;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.File;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("file")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class FileController : AppBaseController
{
    private readonly IFileSystem fileSystem;

    public FileController(IMediator mediator, IMapper mapper, IFileSystem fileSystem) : base(mediator, mapper)
    {
        this.fileSystem = fileSystem;
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(FileViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var file = await Mediator.Send(new GetFileByIdQuery(id));

        if (file == null)
        {
            return NotFound();
        }

        var fileViewModel = Mapper.Map<FileViewModel>(file);

        return Ok(fileViewModel);
    }

    [HttpGet]
    [Route("{id:int}/file-contents")]
    [ProducesResponseType(typeof(FileStream), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFileContents(int id)
    {
        var file = await Mediator.Send(new GetFileByIdQuery(id));

        if (file == null)
        {
            return NotFound();
        }

        var filePath = fileSystem.GetAbsolutePath(file.Path);
        var fileContents = System.IO.File.OpenRead(filePath);

        return File(fileContents, "application/octet-stream", file.Name);
    }

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

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var file = await Mediator.Send(new GetFileByIdQuery(id));

        if (file == null)
        {
            return NotFound();
        }

        await Mediator.Send(new DeleteFileCommand(file));

        return Ok();
    }
}