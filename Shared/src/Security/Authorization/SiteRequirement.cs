using Microsoft.AspNetCore.Authorization;

namespace Nebula.Shared.Security.Authorization;

public class SiteRequirement : IAuthorizationRequirement
{
    public const string Name = "Site";
}