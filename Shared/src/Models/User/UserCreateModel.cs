namespace Nebula.Shared.Models.User;

public class UserCreateModel : CreateModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? Password { get; set; }
    public string? ConfirmationPassword { get; set; }
    public int RoleId { get; set; }
}