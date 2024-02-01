using System;
using System.Collections.Generic;
using System.Linq;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.Complex;
using Nebula.Clients.FCB.Shared.Models.LeaseAgreement;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Extensions;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.House;

public class HouseViewModel : ViewModel
{
    public string Code { get; set; } = null!;
    public string ItemCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Memo { get; set; } = null!;
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
    public DateTime? ConstructionDate { get; set; }
    public DateTime? AppraisalDate { get; set; }
    public DateTime? RenovationDate { get; set; }
    public decimal MarketValue { get; set; }
    public decimal ConstructionCosts { get; set; }
    public decimal? RenovationCosts { get; set; }
    public decimal? GroundLease { get; set; }
    public decimal RentBasePrice { get; set; }
    public int RentBasePoints { get; set; }
    public bool Rented => LeaseAgreements.Any(la => la.EndDate > DateTime.UtcNow || la.EndDate is null);

    public NeighborhoodViewModel Neighborhood { get; set; } = null!;
    public int NeighborhoodId { get; set; }
    public ComplexViewModel Complex { get; set; } = null!;
    public int ComplexId { get; set; }
    public IList<LeaseAgreementViewModel> LeaseAgreements { get; set; } = null!;

    public string DisplayName => $"{Address.TruncateWithEllipsis(150)} - {Code}";

    public LeaseAgreementViewModel? LeaseAgreement => LeaseAgreements.FirstOrDefault(la => la.EndDate > DateTime.UtcNow || la.EndDate == null);

    public ClientViewModel? Tenant =>
        LeaseAgreements.Where(la => la.EndDate > DateTime.UtcNow || la.EndDate is null).Select(la => la.Client).FirstOrDefault();

}