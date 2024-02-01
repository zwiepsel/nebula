using System;
using Nebula.Core.Api.Domain.Entities.Identity;

namespace Nebula.Core.Api.Domain.Entities;

public class Entity : IEntity
{
    public int Id { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public int? DeletedById { get; set; }
    public virtual User? DeletedBy { get; set; }

    public int? UpdatedById { get; set; }
    public virtual User? UpdatedBy { get; set; }

    public int CreatedById { get; set; }
    public virtual User CreatedBy { get; set; } = null!;
}