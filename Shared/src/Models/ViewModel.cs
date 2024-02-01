using System;

namespace Nebula.Shared.Models;

public abstract class ViewModel : Model
{
    public int Id { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}