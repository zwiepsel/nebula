using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nebula.Shared.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IMapper Mapper { get; }
    protected IMediator Mediator { get; }
    
    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mapper = mapper;
        Mediator = mediator;
    }
}