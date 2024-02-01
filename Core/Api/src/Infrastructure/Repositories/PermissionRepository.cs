using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IList<Permission>> FindBySiteId(int siteId, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Permissions.Where(permission => permission.SiteId == siteId && permission.Deleted == false).ToListAsync(cancellationToken);
    }

    public async Task<Permission?> FindBySiteIdAndSystemName(int siteId, string systemName, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Permissions.FirstOrDefaultAsync(permission => permission.SiteId == siteId && permission.SystemName == systemName && permission.Deleted == false, cancellationToken);
    }
}