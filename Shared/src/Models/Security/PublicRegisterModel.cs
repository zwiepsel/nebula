namespace Nebula.Shared.Models.Security;

public class PublicRegisterModel : CreateModel
{
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmationPassword { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int SiteId { get; set; }
}