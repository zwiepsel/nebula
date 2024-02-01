using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;

public interface IRiskRepository : IBaseRepository<Risk>
{
    public Task<IList<Risk>> FindByReminderDate(DateTime reminderDate, CancellationToken cancellationToken = default);
}