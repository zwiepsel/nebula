using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class ProcessType : Entity
{
    public string Description { get; set; } = null!;
    public int TriggerTypeId { get; set; }
    public virtual TriggerType TriggerType { get; set; } = null!;
    public int? RequestTypeId { get; set; }
    public virtual RequestType? RequestType { get; set; } = null!;
    public int ProcessTypeIdComplete { get; set; }

}