using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    public Task<List<Client>> FindApplicants(CancellationToken cancellationToken = default);
    public Task<List<Client>> FindTenants(CancellationToken cancellationToken = default);
}