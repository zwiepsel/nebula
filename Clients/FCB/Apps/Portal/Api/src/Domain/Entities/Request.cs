
using System.Collections.Generic;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Request : Entity
{
    public int RequestTypeId { get; set; }
    public virtual RequestType RequestType { get; set; } = null!;
    public int ProcessId { get; set; }
    public virtual IList<Process> Processes { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public int? HouseId { get; set; }
    public virtual House? House { get; set; }
    
    public int? ClientId { get; set; }
    public virtual Client? Client { get; set; }
    
    public int? PersonId { get; set; }
    public virtual Person? Person { get; set; }
    
    public int? SiteUserId { get; set; }
    public string? Ref1 { get; set; }
    public string? Ref2 { get; set; }
    public string? Ref3 { get; set; }
    public int IncomeScaleId { get; set; }
    public virtual IncomeScale IncomeScale { get; set; } = null!;

    public int AdultQty { get; set; }
    public int ChildrenQty { get; set; }
    public int RequestStatusId { get; set; }
    public virtual List<Task> Tasks { get; set; } = null!;

}