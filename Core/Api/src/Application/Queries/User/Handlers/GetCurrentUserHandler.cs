using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Application.Queries.User.Handlers;

public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, Domain.Entities.Identity.User?>
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, UserManager<Domain.Entities.Identity.User> userManager)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.userManager = userManager;
    }

    public async Task<Domain.Entities.Identity.User?> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return await userManager.FindByIdAsync(userManager.GetUserId(httpContextAccessor.HttpContext?.User));
    }
}