using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class AgeScaleRepository: BaseRepository<AgeScale, IDatabaseContext>, IAgeScaleRepository
{
    public AgeScaleRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
        
    }
}