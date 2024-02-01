namespace Nebula.Shared.Models.Security;

public class ChangePasswordModel : Model
{
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public string? ConfirmationPassword { get; set; }
}