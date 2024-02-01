using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Nebula.Core.Api.Application.Queries.Role.Handlers
{
    public class GetRoleByNameHandler : IRequestHandler<GetRoleByNameQuery, Domain.Entities.Identity.Role>
    {
        private readonly RoleManager<Domain.Entities.Identity.Role> roleManager;

        public GetRoleByNameHandler(RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<Domain.Entities.Identity.Role> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            return await roleManager.Roles.FirstAsync(role => role.Name == request.RoleName, cancellationToken);
        }
    }
}