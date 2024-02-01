using System;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class ProcessDetail : Entity
{
    public int ProcessId { get; set; }
    public virtual Process Process { get; set; } = null!;
    public int Step { get; set; }
    public string StepName { get; set; } = null!;
    public int AfterStep { get; set; }
    [Column(TypeName = "date")]
    public DateTime DueDate { get; set; }
    public int? SiteUserId { get; set; }
    public int? SiteUserGroupId { get; set; }

}