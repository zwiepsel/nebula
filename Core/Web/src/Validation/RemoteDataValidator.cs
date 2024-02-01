using System.Threading.Tasks;
using Nebula.Core.Shared.Validation;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Exceptions.Http;

namespace Nebula.Core.Web.Validation;

public class RemoteDataValidator : IRemoteDataValidator
{
    private readonly CoreApi coreApi;

    public RemoteDataValidator(CoreApi coreApi)
    {
        this.coreApi = coreApi;
    }

    public async Task<bool> UniquePermissionSystemName(string permissionSystemName)
    {
        try
        {
            await coreApi.GetAsync($"validation/unique-permission-system-name/{permissionSystemName}");
        }
        catch (ConflictHttpException)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> UniqueGroupSystemName(string groupSystemName)
    {
        try
        {
            await coreApi.GetAsync($"validation/unique-group-system-name/{groupSystemName}");
        }
        catch (ConflictHttpException)
        {
            return false;
        }

        return true;
    }
}