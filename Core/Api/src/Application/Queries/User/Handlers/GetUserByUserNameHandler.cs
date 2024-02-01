using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Application.Queries.User.Handlers;

public class GetUserByUserNameHandler : IRequestHandler<GetUserByUserNameQuery, Domain.Entities.Identity.User?>
{
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetUserByUserNameHandler(UserManager<Domain.Entities.Identity.User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<Domain.Entities.Identity.User?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
    {
        return await userManager.FindByNameAsync(request.UserName);
    }
}