using System.Collections.Generic;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Process : Entity
{
    public int ProcessStructureId { get; set; }
    public int ProcessTypeId { get; set; }
    public virtual ProcessType ProcessType { get; set; } = null!;
    public virtual List<ProcessDetail> ProcessDetails { get; set; } = null!;
    public virtual List<Request> Requests { get; set; } = null!;
    public string Description { get; set; } = null!;

}