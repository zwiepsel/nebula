using Nebula.Shared.Clients.Data;
using Nebula.Shared.Clients.Repositories;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Web.Repositories;

public class UserRepository : BaseCrudRepository<UserViewModel, UserViewModel, UserCreateModel, UserUpdateModel>
{
    public UserRepository(CoreApi api) : base(api, "admin/user")
    {
    }
}