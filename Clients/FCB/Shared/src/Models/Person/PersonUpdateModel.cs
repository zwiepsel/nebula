using System;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Person;

public class PersonUpdateModel : UpdateModel
{
    public string FirstName { get; set; } = null!;
    public string? Prefix { get; set; }
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;

    public Gender Gender { get; set; }
    public string? EmailAddress { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string CountryOfBirth { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public bool SchoolGoing { get; set; }
    public bool LeftHome { get; set; }
    public bool MainContact { get; set; }
    public bool Deleted { get; set; }
    public bool InActive { get; set; } = false;
    public RelationType RelationType { get; set; }
}