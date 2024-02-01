using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Application.Queries.Site;
using Nebula.Core.Api.Application.Queries.User;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Api.Controllers;

namespace Nebula.Core.Api.Infrastructure.Controllers;

public abstract class Controller : BaseController
{
    protected Controller(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    protected async Task<User?> GetCurrentUser()
    {
        return await Mediator.Send(new GetCurrentUserQuery());
    }

    protected async Task<Site?> GetCurrentSite()
    {
        return await Mediator.Send(new GetCurrentSiteQuery());
    }
}