using System.Threading;
using System.Threading.Tasks;
using Nebula.Core.Api.Domain.Entities;

namespace Nebula.Core.Api.Domain.Repositories;

public interface ISiteRepository : IRepository<Site>
{
    public Task<Site> GetCore(CancellationToken cancellationToken = default);
    public Task<Site?> FindByHost(string host, CancellationToken cancellationToken = default);
}