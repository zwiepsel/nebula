using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IList<Group>> FindBySiteId(int siteId, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Groups.Where(group => group.SiteId == siteId && group.Deleted == false).ToListAsync(cancellationToken);
    }

    public async Task<Group?> FindBySiteIdAndSystemName(int siteId, string systemName, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Groups.FirstOrDefaultAsync(group => group.SiteId == siteId && group.SystemName == systemName && group.Deleted == false, cancellationToken);
    }
}