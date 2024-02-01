using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Nebula.Core.Api.Application.Queries.User.Handlers;

public class GetUserByEmailAddressHandler : IRequestHandler<GetUserByEmailAddressQuery, Domain.Entities.Identity.User?>
{
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetUserByEmailAddressHandler(UserManager<Domain.Entities.Identity.User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<Domain.Entities.Identity.User?> Handle(GetUserByEmailAddressQuery request, CancellationToken cancellationToken)
    {
        return await userManager.FindByEmailAsync(request.EmailAddress);
    }
}