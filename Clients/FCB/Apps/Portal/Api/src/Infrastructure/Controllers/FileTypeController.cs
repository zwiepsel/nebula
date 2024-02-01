using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.FileType;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Security.Authorization;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Controllers;

[ApiController]
[Route("file-type")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteRequirement.Name)]
public class FileTypeController : AppBaseController
{
    public FileTypeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<FileTypeViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var fileTypes = await Mediator.Send(new GetAllFileTypesQuery());
        var fileTypeViewModels = Mapper.Map<IList<FileTypeViewModel>>(fileTypes);

        return Ok(fileTypeViewModels);
    }


    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(FileTypeViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var fileType = await Mediator.Send(new GetFileTypeByIdQuery(id));

        if (fileType == null)
        {
            return NotFound();
        }

        var fileTypeViewModel = Mapper.Map<FileTypeViewModel>(fileType);

        return Ok(fileTypeViewModel);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(FileTypeViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Create(FileTypeCreateModel fileTypeCreateModel)
    {
        var fileType = await Mediator.Send(new CreateFileTypeCommand(fileTypeCreateModel));
        var fileTypeViewModel = Mapper.Map<FileTypeViewModel>(fileType);

        return Ok(fileTypeViewModel);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(FileTypeViewModel), StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = SiteAdministratorRequirement.Name)]
    public async Task<IActionResult> Update(int id, FileTypeUpdateModel fileTypeUpdateModel)
    {
        if (id != fileTypeUpdateModel.Id)
        {
            return BadRequest();
        }

        var fileType = await Mediator.Send(new GetFileTypeByIdQuery(id));

        if (fileType == null)
        {
            return NotFound();
        }

        fileType = await Mediator.Send(new UpdateFileTypeCommand(fileType, fileTypeUpdateModel));
        var fileTypeViewModel = Mapper.Map<FileTypeViewModel>(fileType);

        return Ok(fileTypeViewModel);
    }
}