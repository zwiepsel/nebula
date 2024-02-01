﻿using System;

namespace Nebula.Shared.Api.Entities;

public interface IBaseEntity
{
    public int Id { get; set; }

    public bool Deleted { get; set; }

    public int? DeletedById { get; set; }
    public int? UpdatedById { get; set; }
    public int CreatedById { get; set; }

    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}