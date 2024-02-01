using AutoMapper;
using Nebula.Shared.Models.App;
using Nebula.Shared.Models.Client;
using Nebula.Shared.Models.Group;
using Nebula.Shared.Models.Site;
using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Web.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        // Apps.
        CreateMap<AppViewModel, AppUpdateModel>();
        CreateMap<AppUpdateModel, AppViewModel>();

        // Clients.
        CreateMap<ClientViewModel, ClientUpdateModel>();
        CreateMap<ClientUpdateModel, ClientViewModel>();

        // Groups.
        CreateMap<GroupViewModel, GroupUpdateModel>();
        CreateMap<GroupUpdateModel, GroupViewModel>();

        // Sites.
        CreateMap<SiteViewModel, SiteUpdateModel>();
        CreateMap<SiteUpdateModel, SiteViewModel>();

        // Site users.
        CreateMap<SiteUserViewModel, SiteUserUpdateModel>();
        CreateMap<SiteUserUpdateModel, SiteUserViewModel>();

        // Users.
        CreateMap<UserViewModel, UserUpdateModel>();
        CreateMap<UserUpdateModel, UserViewModel>();
    }
}