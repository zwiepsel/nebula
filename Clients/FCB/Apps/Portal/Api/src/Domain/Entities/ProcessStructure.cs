

using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class ProcessStructure : Entity
{
    public int ProcessTypeId { get; set; }
    public virtual ProcessType ProcessType { get; set; } = null!;
    public int StepNr { get; set; }
    public string StepName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? AfterStep { get; set; }
    public string? QueryCondition { get; set; } = null!;
    public int CompletionDays { get; set; }
    public int? SiteUserId { get; set; }
    public int? SiteUserGroupId { get; set; }
}