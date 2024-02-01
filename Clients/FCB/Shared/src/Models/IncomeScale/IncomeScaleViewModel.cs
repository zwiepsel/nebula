using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.IncomeScale;

public class IncomeScaleViewModel : ViewModel
{
    public string? Scale { get; set; } = null!;
    public double MinAmount { get; set; }
    public double MaxAmount { get; set; }
    public double Percentage { get; set; }
    public string RentClass { get; set; } = null!;
}