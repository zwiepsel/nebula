using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.Permission;

namespace Nebula.Core.Web.Repositories.SiteSettings;

public class SiteSettingsPermissionRepository : BaseRepository
{
    public SiteSettingsPermissionRepository(CoreApi api) : base(api)
    {
    }

    public async Task<IList<PermissionViewModel>> GetPermissionsBySite(int siteId, CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<PermissionViewModel>>($"site-settings/{siteId}/permission", cancellationToken);
    }

    public async Task<PermissionViewModel> Create(int siteId, PermissionCreateModel createModel, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<PermissionViewModel>($"site-settings/{siteId}/permission", createModel, cancellationToken);
    }

    public async Task<PermissionViewModel> Update(int siteId, PermissionUpdateModel updateModel, CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<PermissionViewModel>($"site-settings/{siteId}/permission/{updateModel.Id}", updateModel, cancellationToken);
    }
}