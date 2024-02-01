using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class IncomeScaleRepository: BaseRepository<IncomeScale, IDatabaseContext>, IIncomeScaleRepository
{
    public IncomeScaleRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
        
    }
}