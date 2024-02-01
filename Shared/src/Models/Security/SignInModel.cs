namespace Nebula.Shared.Models.Security;

public class SignInModel : Model
{
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int SiteId { get; set; }
}