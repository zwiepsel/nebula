using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Client;

public class ClientCreateModel : CreateModel
{
    public string Name { get; set; } = null!;
 
    public int ClientTypeId { get; set; } 
    [Column(TypeName = "decimal(19,4)")]
    public string? DebtorCode { get; set; } = null!;
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    [MaxLength(100)]
    public string? Address { get; set; } = null!;
    public int Bedrooms { get; set; }
    public int AdultQty { get; set; }
    public int ChildrenQty { get; set; }
    public int MinorQty { get; set; }
    public ClientStatus ClientStatus { get; set; } 

    [Column(TypeName = "decimal(19,4)")]
    public decimal YearlyIncome { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal MaxRent { get; set; }
    [Column(TypeName = "decimal(3,2)")]
    public decimal ChildDiscount { get; set; }
    public bool InterestedInBuying { get; set; }
    public bool LookingForHouse { get; set; }
    public string? AgeClass { get; set; } = null!;
    public string? FamilyState { get; set; } = null!;

    [Column(TypeName = "Date")]
    public DateTime? ApplicationDate { get; set; }

    public bool Urgency { get; set; } = false;
    public int? ApplicantPreferredNeighborhood1Id { get; set; }

    public bool InActive { get; set; } = false;
    public int? ApplicantPreferredNeighborhood2Id { get; set; }

    public string? Memo { get; set; } = null!;
    public int? ApplicantPreferredNeighborhood3Id { get; set; }

}