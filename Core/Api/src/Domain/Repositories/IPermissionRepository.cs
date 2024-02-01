using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Core.Api.Domain.Entities;

namespace Nebula.Core.Api.Domain.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    public Task<IList<Permission>> FindBySiteId(int siteId, CancellationToken cancellationToken = default);
    public Task<Permission?> FindBySiteIdAndSystemName(int siteId, string systemName, CancellationToken cancellationToken = default);
}