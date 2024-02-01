using Microsoft.AspNetCore.Authorization;

namespace Nebula.Shared.Security.Authorization;

public class AdministratorRequirement : IAuthorizationRequirement
{
    public const string Name = "Administrator";
}