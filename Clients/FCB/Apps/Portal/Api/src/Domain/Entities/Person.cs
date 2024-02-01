using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;

public class Person : Entity
{
    [MaxLength(100)]
    public string? FirstName { get; set; } = null!;

    [MaxLength(50)]
    public string? Prefix { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; } = null!;


    [MaxLength(100)]
    public string? EmailAddress { get; set; }

    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool MainContact { get; set; }
    public RelationType? RelationType { get; set; }
    public Gender Gender { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    [MaxLength(100)]
    public string? CountryOfBirth { get; set; } = null!;

    [MaxLength(100)]
    public string? Nationality { get; set; } = null!;

    public bool SchoolGoing { get; set; }
    public bool LeftHome { get; set; }
    public bool InActive { get; set; } = false;

    
    public virtual IList<Income>? Incomes { get; set; } = null!;
    public int ClientId { get; set; } 
    public virtual Client Client { get; set; } = null!;
    public string? Memo { get; set; } = null!;
    [NotMapped]
    public string FullName => Prefix == null ? $"{FirstName} {LastName}" : $"{FirstName} {Prefix} {LastName}";
}