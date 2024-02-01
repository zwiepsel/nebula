using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Exceptions.Http;
using Nebula.Shared.Models.Site;

namespace Nebula.Core.Web.Repositories;

public class SiteRepository : BaseCrudRepository<SiteViewModel, SiteViewModel, SiteCreateModel, SiteUpdateModel>
{
    private SiteViewModel? core;

    public SiteRepository(CoreApi api) : base(api, "admin/site")
    {
    }

    public async Task<SiteViewModel> GetCore(CancellationToken cancellationToken = default)
    {
        if (core == null)
        {
            core = await Api.GetAsync<SiteViewModel>("site/core", cancellationToken);
        }

        return core;
    }

    public async Task<SiteViewModel> FindByHost(string host, CancellationToken cancellationToken = default)
    {
        try
        {
            return await Api.GetAsync<SiteViewModel>($"site/{host}", cancellationToken);
        }
        catch (NotFoundHttpException)
        {
            return await GetCore(cancellationToken);
        }
    }
}