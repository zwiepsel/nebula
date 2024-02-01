using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Models;
using Nebula.Shared.Utilities;

namespace Nebula.Clients.FCB.Shared.Models.Client;


public class ClientIndexViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public string? DebtorCode { get; set; } = null!;

    [MaxLength(100)]
    public string? Address { get; set; } = null!;

    public int Bedrooms { get; set; }
    public int AdultQty { get; set; }
    public int ChildrenQty { get; set; }
    public int MinorQty { get; set; }
    public bool InterestedInBuying { get; set; }
    public bool LookingForHouse { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal YearlyIncome { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal MaxRent { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    public decimal ChildDiscount { get; set; }
    public int ClientTypeId { get; set; } 
    public string? YearlyIncomeClass { get; set; } = null!;
    public string? AgeClass { get; set; } = null!;
    public string? FamilyState { get; set; } = null!;

    [Column(TypeName = "Date")]
    public DateTime? ApplicationDate { get; set; }

    public bool Urgency { get; set; } = false;
    public int? ApplicantPreferredNeighborhood1Id { get; set; }
    public virtual NeighborhoodViewModel? ApplicantPreferredNeighborhood1 { get; set; }
    public ClientStatus ClientStatus { get; set; } 
    public int? ApplicantPreferredNeighborhood2Id { get; set; }
    public virtual NeighborhoodViewModel? ApplicantPreferredNeighborhood2 { get; set; }
    public string? Memo { get; set; } = null!;
    public int? ApplicantPreferredNeighborhood3Id { get; set; }
    public virtual NeighborhoodViewModel? ApplicantPreferredNeighborhood3 { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal RentAmount { get; set; }
    public bool Applicant => ClientTypeId == 1;
    public bool Tenant => ClientTypeId == 2;
    
    public string ApplicantPreferredNeighborhoodFilter =>
        $"{HashGenerator.Sha1(ApplicantPreferredNeighborhood1?.Id)}|{HashGenerator.Sha1(ApplicantPreferredNeighborhood2?.Id)}|{HashGenerator.Sha1(ApplicantPreferredNeighborhood3?.Id)}";

}
