using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Shared.Api.Utilities;
using Nebula.Shared.Models.User;

namespace Nebula.Shared.Api.Controllers;

public abstract class AppBaseController : BaseController
{
    protected AppBaseController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    protected async Task<UserViewModel> GetCurrentUser()
    {
        return await CoreApiHttpClient.Get<UserViewModel>("me/user");
    }
}