using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Income : Entity
{
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal Amount { get; set; }

    public IncomeType Type { get; set; }
    public IncomePayPeriod Period { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = null!;

    [NotMapped]
    public decimal YearlyAmount => GetYearlyAmount();

    private decimal GetYearlyAmount()
    {
        return Period switch
        {
            IncomePayPeriod.Weekly => Amount * 52,
            IncomePayPeriod.Fortnightly => Amount * 26,
            IncomePayPeriod.FourWeekly => Amount * 13,
            IncomePayPeriod.Monthly => Amount * 12,
            IncomePayPeriod.Yearly => Amount,
            IncomePayPeriod.Quincena => Amount * 26,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}