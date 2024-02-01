using Microsoft.AspNetCore.Authorization;

namespace Nebula.Shared.Security.Authorization;

public class SiteAdministratorRequirement : IAuthorizationRequirement
{
    public const string Name = "SiteAdministrator";
}