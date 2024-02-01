using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.AgeScale;

public class AgeScaleViewModel : ViewModel
{
    public string Scale { get; set; } = null!;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
}