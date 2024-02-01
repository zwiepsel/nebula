using System;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Income;

public class IncomeViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public decimal YearlyAmount { get; set; }
    public IncomeType Type { get; set; }
    public IncomePayPeriod Period { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PersonId { get; set; }
    public bool Deleted { get; set; }

    public PersonViewModel Person { get; set; } = null!;
}