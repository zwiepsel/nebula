using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Api.Entities;


namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities
{
    public class Client : Entity
    {
        [MaxLength(100)]
        public string? Name { get; set; } = null!;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(20)]
        public string? DebtorCode { get; set; } = null!;

        [MaxLength(100)]
        public string? Address { get; set; } = null!;

        public int Bedrooms { get; set; }
        public int AdultQty { get; set; }
        public int ChildrenQty { get; set; }
        public int MinorQty { get; set; }


        [Column(TypeName = "decimal(19,4)")]
        public decimal YearlyIncome { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        public decimal MaxRent { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal ChildDiscount { get; set; }

        public string? YearlyIncomeClass { get; set; } = null!;
        public string? AgeClass { get; set; } = null!;
        public string? FamilyState { get; set; } = null!;

        [Column(TypeName = "Date")]
        public DateTime? ApplicationDate { get; set; }
        public bool InterestedInBuying { get; set; }
        public bool LookingForHouse { get; set; }
        public bool Urgency { get; set; } = false;
        public int? ApplicantPreferredNeighborhood1Id { get; set; }
        public virtual Neighborhood? ApplicantPreferredNeighborhood1 { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public int? ApplicantPreferredNeighborhood2Id { get; set; }
        public virtual Neighborhood? ApplicantPreferredNeighborhood2 { get; set; }
        public string? Memo { get; set; } = null!;
        public int? ApplicantPreferredNeighborhood3Id { get; set; }
        public virtual Neighborhood? ApplicantPreferredNeighborhood3 { get; set; }

        public virtual IList<Person> Persons { get; set; } = null!;
        public virtual IList<LeaseAgreement> LeaseAgreements { get; set; } = null!;
        public virtual ClientType ClientType { get; set; } = null!;
        public int ClientTypeId { get; set; }

    }
}