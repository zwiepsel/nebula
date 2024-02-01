using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Nebula.Core.Api.Application.Queries.Role.Handlers
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Domain.Entities.Identity.Role>>
    {
        private readonly RoleManager<Domain.Entities.Identity.Role> roleManager;

        public GetAllRolesHandler(RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<Domain.Entities.Identity.Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await roleManager.Roles.Where(role => role.Deleted == false).ToListAsync(cancellationToken);
        }
    }
}