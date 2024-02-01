using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Core.Api.Domain.Entities;

namespace Nebula.Core.Api.Domain.Repositories;

public interface ISiteUserRepository : IRepository<SiteUser>
{
    public Task<IList<SiteUser>> FindBySiteId(int siteId, CancellationToken cancellationToken = default);
}