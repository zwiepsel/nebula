using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class LeaseAgreement : Entity
{
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
    public virtual Client Client { get; set; } = null!;
    
    [Column(TypeName = "decimal(19,2)")]
    public decimal DepositValue { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime? DepositDate { get; set; }
    public int HouseId { get; set; }
    
    public virtual House House { get; set; } = null!;
    public virtual IList<Rent> Rents { get; set; } = null!;
}