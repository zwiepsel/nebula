using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Application.Queries.User.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.Identity.User?>
{
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetUserByIdHandler(UserManager<Domain.Entities.Identity.User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<Domain.Entities.Identity.User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await userManager.FindByIdAsync(request.Id.ToString());
    }
}