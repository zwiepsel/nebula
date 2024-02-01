using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Enums;

namespace Nebula.Core.Api.Application.Queries.Role.Handlers
{
    public class GetCoreRolesHandler : IRequestHandler<GetCoreRolesQuery, IEnumerable<Domain.Entities.Identity.Role>>
    {
        private readonly RoleManager<Domain.Entities.Identity.Role> roleManager;

        public GetCoreRolesHandler(RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<Domain.Entities.Identity.Role>> Handle(GetCoreRolesQuery request, CancellationToken cancellationToken)
        {
            return await roleManager.Roles.Where(role => role.Type == RoleType.Core && role.Deleted == false).ToListAsync(cancellationToken);
        }
    }
}