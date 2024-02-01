
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class IncomeScale : Entity
{
    public string Scale { get; set; } = null!;
    public double MinAmount { get; set; }
    public double MaxAmount { get; set; }
    public double Percentage { get; set; }
    public string RentClass { get; set; } = null!;
}