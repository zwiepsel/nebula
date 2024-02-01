using System;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Rent : Entity
{
    [Column(TypeName = "decimal(19,4)")]
    public decimal AskPrice { get; set; }

    public int LeaseAgreementId { get; set; }
    public virtual LeaseAgreement LeaseAgreement { get; set; } = null!;
    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal ContractPrice  { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal RentPrice  { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal Discount  { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal PointValue  { get; set; }
}