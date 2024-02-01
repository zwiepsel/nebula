using System.Threading.Tasks;

namespace Nebula.Core.Shared.Validation;

public interface IRemoteDataValidator
{
    public Task<bool> UniquePermissionSystemName(string permissionSystemName);
    public Task<bool> UniqueGroupSystemName(string groupSystemName);
}