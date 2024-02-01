namespace Nebula.Shared.Models.User;

public class UserUpdateModel : UpdateModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Password { get; set; }
    public string? ConfirmationPassword { get; set; }
    public int RoleId { get; set; }
}