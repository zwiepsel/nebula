using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class AppRepository : Repository<App>, IAppRepository
{
    public AppRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}