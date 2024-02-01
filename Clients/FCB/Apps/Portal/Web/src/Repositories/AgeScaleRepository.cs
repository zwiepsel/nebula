using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.AgeScale;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class AgeScaleRepository : BaseRepository
{
    public AgeScaleRepository(AppApi api) : base(api)
    {
    }
    
    public async Task<AgeScaleViewModel> Get(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<AgeScaleViewModel>($"ageScale", cancellationToken);
    }
}
    
