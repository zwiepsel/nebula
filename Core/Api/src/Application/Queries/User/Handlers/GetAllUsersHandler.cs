using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Nebula.Core.Api.Application.Queries.User.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<Domain.Entities.Identity.User>>
{
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetAllUsersHandler(UserManager<Domain.Entities.Identity.User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<IEnumerable<Domain.Entities.Identity.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await userManager.Users.ToListAsync(cancellationToken);
    }
}