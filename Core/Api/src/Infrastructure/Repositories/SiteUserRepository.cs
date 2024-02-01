using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;
using Nebula.Shared.Constants;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class SiteUserRepository : Repository<SiteUser>, ISiteUserRepository
{
    public SiteUserRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IList<SiteUser>> FindBySiteId(int siteId, CancellationToken cancellationToken = default)
    {
        var siteUsers = await DatabaseContext.SiteUsers.Where(siteUser => siteUser.SiteId == siteId && siteUser.Deleted == false).ToListAsync(cancellationToken);

        return siteUsers.Where(siteUser => siteUser.User.IsInRole(CoreRoles.User)).ToList();
    }
}