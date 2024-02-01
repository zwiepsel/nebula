using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Shared.Models.AgeScale;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicAgeScaleRepository : BaseRepository
{
    public PublicAgeScaleRepository(AppApi api) : base(api)
    {
    }
    
    public async Task<List<AgeScaleViewModel>> Get(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<List<AgeScaleViewModel>>($"public/ageScale", cancellationToken);
    }
}
