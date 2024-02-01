using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.SiteUser;

namespace Nebula.Core.Web.Repositories.SiteSettings;

public class SiteSettingsSiteUserRepository : BaseRepository
{
    public SiteSettingsSiteUserRepository(CoreApi api) : base(api)
    {
    }

    public async Task<IList<SiteUserViewModel>> GetSiteUsersBySite(int siteId, CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<SiteUserViewModel>>($"site-settings/{siteId}/site-user", cancellationToken);
    }

    public async Task<SiteUserViewModel> Create(int siteId, SiteUserCreateModel createModel, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<SiteUserViewModel>($"site-settings/{siteId}/site-user", createModel, cancellationToken);
    }

    public async Task<SiteUserViewModel> Update(int siteId, SiteUserUpdateModel updateModel, CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<SiteUserViewModel>($"site-settings/{siteId}/site-user/{updateModel.Id}", updateModel, cancellationToken);
    }
}