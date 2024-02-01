using System;

namespace Nebula.Shared.Models.Security;

public class ApiTokenModel : Model
{
    public string Token { get; set; } = null!;
    public DateTime Expiration { get; set; }
}