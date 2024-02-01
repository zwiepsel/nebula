using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.House;

public class HouseIndexViewModel : ViewModel
{
    public string Code { get; set; } = null!;
    public string Address { get; set; } = null!;
    public HouseType Type { get; set; }
    public Ownership Ownership { get; set; }
    public HouseStatus Status { get; set; }
    public int NumberOfBedrooms { get; set; }
    public int SquareMetersBvo { get; set; }
    public int SquareMetersGo { get; set; }
    public int SquareMetersFcb { get; set; }
    public string? Collateral { get; set; } 

    public decimal CollateralValue { get; set; }
    public string LandRegistryNumber { get; set; } = null!;
    public decimal MarketValue { get; set; }
    public string? Memo { get; set; } = null!;
    public bool Rented { get; set; }
    public string NeighborhoodName { get; set; } = null!;
    public string ComplexName { get; set; } = null!;
    public string? TenantFullName { get; set; }
    public decimal? RentAmount { get; set; }
    
}