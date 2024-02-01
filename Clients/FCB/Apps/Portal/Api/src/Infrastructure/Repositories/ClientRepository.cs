
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class ClientRepository : BaseRepository<Client, IDatabaseContext>, IClientRepository
{
    public ClientRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {

    }
    
    public async Task<List<Client>> FindApplicants(CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Clients.Where(client => client.ClientStatus == ClientStatus.Active && client.ClientType.Id == 1).ToListAsync(cancellationToken);

    }

    public async Task<List<Client>> FindTenants(CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Clients.Where(client => client.ClientStatus == ClientStatus.Active && client.ClientType.Id == 2).ToListAsync(cancellationToken);
    }
}