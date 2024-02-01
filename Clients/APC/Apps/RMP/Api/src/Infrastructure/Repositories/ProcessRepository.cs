using Nebula.Clients.APC.Apps.RMP.Api.Domain.Data;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Repositories;

public class ProcessRepository : BaseRepository<Process, IDatabaseContext>, IProcessRepository
{
    public ProcessRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}