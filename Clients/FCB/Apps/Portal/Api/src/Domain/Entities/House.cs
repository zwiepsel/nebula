using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class House : Entity
{
    [MaxLength(50)]
    public string Code { get; set; } = null!;

    [MaxLength(100)]
    public string ItemCode { get; set; } = null!;

    [MaxLength(100)]
    public string Address { get; set; } = null!;
    public string? Memo { get; set; } = null!;
    public HouseType Type { get; set; } = HouseType.Vrijstaand;
    public HouseStatus Status { get; set; } = HouseStatus.Empty;
    public Ownership Ownership { get; set; } = Ownership.Economisch;
    public int NumberOfBedrooms { get; set; }
    public int SquareMetersBvo { get; set; }
    public int SquareMetersGo { get; set; }
    public int SquareMetersFcb { get; set; }
    public string? Collateral { get; set; } 
    [Column(TypeName = "decimal(19,4)")]
    public decimal CollateralValue { get; set; }

    [MaxLength(100)]
    public string? LandRegistryNumber { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ConstructionDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? AppraisalDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? RenovationDate { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal MarketValue { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal ConstructionCosts { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal? RenovationCosts { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal? GroundLease { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal RentBasePrice { get; set; }

    public int RentBasePoints { get; set; }

    public int NeighborhoodId { get; set; }
    public virtual Neighborhood Neighborhood { get; set; } = null!;

    public int ComplexId { get; set; }
    public virtual Complex Complex { get; set; } = null!;

    public virtual IList<LeaseAgreement> LeaseAgreements { get; set; } = null!;
}