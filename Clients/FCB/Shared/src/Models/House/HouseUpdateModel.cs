using System;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.House;

public class HouseUpdateModel : UpdateModel
{
    public string Code { get; set; } = null!;
    public string ItemCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public HouseType Type { get; set; }
    public Ownership Ownership { get; set; }
    public HouseStatus Status { get; set; }
    public string? Memo { get; set; } = null!;
    public int NumberOfBedrooms { get; set; }
    public int SquareMetersBvo { get; set; }
    public int SquareMetersGo { get; set; }
    public int SquareMetersFcb { get; set; }
    public string? Collateral { get; set; } 

    public decimal CollateralValue { get; set; }
    public string LandRegistryNumber { get; set; } = null!;
    public DateTime? ConstructionDate { get; set; }
    public DateTime? AppraisalDate { get; set; }
    public DateTime? RenovationDate { get; set; }
    public decimal MarketValue { get; set; }
    public decimal ConstructionCosts { get; set; }
    public decimal? RenovationCosts { get; set; }
    public decimal? GroundLease { get; set; }
    public decimal RentBasePrice { get; set; }
    public int ComplexId { get; set; }
    public int NeighborhoodId  { get; set; }
    
}