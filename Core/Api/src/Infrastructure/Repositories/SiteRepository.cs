using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class SiteRepository : Repository<Site>, ISiteRepository
{
    public SiteRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<Site> GetCore(CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Sites.FirstAsync(site => site.Core, cancellationToken);
    }

    public async Task<Site?> FindByHost(string host, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Sites.FirstOrDefaultAsync(site => site.Host == host && site.Deleted == false, cancellationToken);
    }
}