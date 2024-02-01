
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.IncomeScale;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class IncomeScaleRepository : BaseRepository
{
    public IncomeScaleRepository(AppApi api) : base(api)
    {
    }
    
    public async Task<List<IncomeScaleViewModel>> Get(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<List<IncomeScaleViewModel>>($"incomeScale", cancellationToken);
    }
}
    
