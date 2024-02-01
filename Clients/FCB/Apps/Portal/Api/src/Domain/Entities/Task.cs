using System;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Task : Entity
{
    public int ProcessDetailId { get; set; }
    public virtual ProcessDetail ProcessDetail { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int SiteUserId { get; set; }
    public int TaskStatusId { get; set; }
    public int Step { get; set; }
    public int AfterStep { get; set; }
    [Column(TypeName = "date")]
    public DateTime DueDate { get; set; }



}