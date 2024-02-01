using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class NeighborhoodRepository : BaseRepository<Neighborhood, IDatabaseContext>, INeighborhoodRepository
{
    public NeighborhoodRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}