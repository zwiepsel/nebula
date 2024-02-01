using System.Threading.Tasks;

namespace Nebula.Shared.Security.Authorization;

public interface IAuthorizationChecker
{
    public Task<bool> IsInGroup(string groupSystemName);
    public Task<bool> HasPermission(string permissionSystemName);
}