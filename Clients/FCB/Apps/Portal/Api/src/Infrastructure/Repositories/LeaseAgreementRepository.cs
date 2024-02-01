using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class LeaseAgreementRepository : BaseRepository<LeaseAgreement, IDatabaseContext>, ILeaseAgreementRepository
{
    public LeaseAgreementRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}