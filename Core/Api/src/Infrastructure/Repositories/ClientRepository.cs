using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}