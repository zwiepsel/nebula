
using System;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.User;

public class RegisterUserModel  : CreateModel
{
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmationPassword { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool AgreeTerms { get; set; } = false;
    public int SiteId { get; set; }
}