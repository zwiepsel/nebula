using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Data;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Repositories;

public class RiskRepository : BaseRepository<Risk, IDatabaseContext>, IRiskRepository
{
    public RiskRepository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IList<Risk>> FindByReminderDate(DateTime reminderDate, CancellationToken cancellationToken = default)
    {
        return await DatabaseContext.Risks.Where(risk => risk.ReminderDate == reminderDate).ToListAsync(cancellationToken);
    }
}