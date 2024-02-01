using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Cache;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Models.Site;
using Nebula.Shared.Models.User;

namespace Nebula.Shared.Clients.State;

public class AppState
{
    private readonly ICache cache;
    private readonly CoreApi coreApi;

    public readonly CultureInfo DefaultCulture = new("en-US");

    public readonly CultureInfo[] SupportedCultures =
    {
        new("en-US"),
        new("nl-NL")
    };

    public AppState(ICache cache, CoreApi coreApi)
    {
        this.cache = cache;
        this.coreApi = coreApi;
    }

    public bool Initialized { get; set; }

    public UserViewModel? User { get; private set; }
    public SiteViewModel Core { get; private set; } = null!;
    public SiteViewModel Site { get; private set; } = null!;

    public async Task Clear()
    {
        await cache.Clear();
    }

    public async Task RefreshCurrentUser(CancellationToken cancellationToken = default)
    {
        User = await coreApi.GetAsync<UserViewModel>("me/user", cancellationToken);
    }

    public void RemoveCurrentUser()
    {
        User = null;
    }

    public void SetCore(SiteViewModel siteViewModel)
    {
        Core = siteViewModel;
    }

    public void SetSite(SiteViewModel siteViewModel)
    {
        Site = siteViewModel;
    }

    public async Task<bool> HasConfiguredCulture()
    {
        return await cache.GetItem<string?>(CacheKeys.Culture) != null;
    }

    public async Task<CultureInfo> GetCurrentCulture()
    {
        var cultureName = await cache.GetItem<string?>(CacheKeys.Culture);

        if (cultureName != null && SupportedCultures.Any(c => c.Name == cultureName))
        {
            return new CultureInfo(cultureName);
        }

        return DefaultCulture;
    }

    public async Task SetCurrentCulture(CultureInfo culture)
    {
        await cache.SetItem(CacheKeys.Culture, culture.Name);
    }
}