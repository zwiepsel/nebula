using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Core.Api.Domain.Entities;

namespace Nebula.Core.Api.Domain.Repositories;

public interface IGroupRepository : IRepository<Group>
{
    public Task<IList<Group>> FindBySiteId(int siteId, CancellationToken cancellationToken = default);
    public Task<Group?> FindBySiteIdAndSystemName(int siteId, string systemName, CancellationToken cancellationToken = default);
}