using System;
using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk;

/// <see cref="GetRisksByReminderDateHandler" />
public class GetRisksByReminderDateQuery : IRequest<IList<Domain.Entities.Risk>>
{
    public GetRisksByReminderDateQuery(DateTime reminderDate)
    {
        ReminderDate = reminderDate;
    }

    public DateTime ReminderDate { get; }
}