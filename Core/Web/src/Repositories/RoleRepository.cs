using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.Role;

namespace Nebula.Core.Web.Repositories;

public class RoleRepository : BaseRepository
{
    public RoleRepository(CoreApi api) : base(api)
    {
    }

    public async Task<IList<RoleViewModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<RoleViewModel>>("role", cancellationToken);
    }

    public async Task<IList<RoleViewModel>> GetCoreRoles(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<RoleViewModel>>("role/core", cancellationToken);
    }

    public async Task<IList<RoleViewModel>> GetSiteRoles(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<RoleViewModel>>("role/site", cancellationToken);
    }
}