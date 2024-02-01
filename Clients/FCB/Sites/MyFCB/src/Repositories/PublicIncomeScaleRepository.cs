using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Shared.Models.IncomeScale;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicIncomeScaleRepository : BaseRepository
{
    public PublicIncomeScaleRepository(AppApi api) : base(api)
    {
    }
    
    public async Task<List<IncomeScaleViewModel>> Get(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<List<IncomeScaleViewModel>>($"public/incomeScale", cancellationToken);
    }
}
