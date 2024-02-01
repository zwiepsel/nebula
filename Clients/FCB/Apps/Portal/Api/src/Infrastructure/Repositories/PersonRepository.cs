
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;

public class PersonRepository : BaseRepository<Person, IDatabaseContext>, IPersonRepository
{
    public PersonRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
        
    }

    public async Task<string?> CalculateScale(decimal yearlyIncome)
    {
        var scales = await DatabaseContext.IncomeScales.ToListAsync();
        return scales.FirstOrDefault(x => Convert.ToDecimal(x.MinAmount) < yearlyIncome && Convert.ToDecimal(x.MaxAmount) > yearlyIncome)?.Scale;
    }

    
}