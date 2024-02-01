using System;
using System.Collections.Generic;
using System.Linq;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Person;

public class PersonViewModel : ViewModel
{
    public string FirstName { get; set; } = null!;
    public string? Prefix { get; set; }
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public Gender Gender { get; set; }
    public string EmailAddress { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string CountryOfBirth { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public bool SchoolGoing { get; set; }
    public bool LeftHome { get; set; }
    public bool InActive { get; set; } = false;
    public bool Deleted { get; set; }
    public bool MainContact { get; set; }
    public virtual IList<IncomeViewModel> Incomes { get; set; } = null!;
    public virtual ClientViewModel Client { get; set; } = null!;
    public RelationType RelationType { get; set; }
    public string FullName { get; set; } = null!;
   public decimal YearlyIncomeAmount => Incomes.Sum(income => income.YearlyAmount);

}