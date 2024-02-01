using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.Group;

namespace Nebula.Core.Web.Repositories.SiteSettings;

public class SiteSettingsGroupRepository : BaseRepository
{
    public SiteSettingsGroupRepository(CoreApi api) : base(api)
    {
    }

    public async Task<IList<GroupViewModel>> GetGroupsBySite(int siteId, CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<GroupViewModel>>($"site-settings/{siteId}/group", cancellationToken);
    }

    public async Task<GroupViewModel> Create(int siteId, GroupCreateModel createModel, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<GroupViewModel>($"site-settings/{siteId}/group", createModel, cancellationToken);
    }

    public async Task<GroupViewModel> Update(int siteId, GroupUpdateModel updateModel, CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<GroupViewModel>($"site-settings/{siteId}/group/{updateModel.Id}", updateModel, cancellationToken);
    }

    public async Task GrantPermission(int siteId, int groupId, int permissionId, CancellationToken cancellationToken = default)
    {
        await Api.PutAsync($"site-settings/{siteId}/group/{groupId}/grant/{permissionId}", new { }, cancellationToken);
    }

    public async Task RevokePermission(int siteId, int groupId, int permissionId, CancellationToken cancellationToken = default)
    {
        await Api.PutAsync($"site-settings/{siteId}/group/{groupId}/revoke/{permissionId}", new { }, cancellationToken);
    }
}