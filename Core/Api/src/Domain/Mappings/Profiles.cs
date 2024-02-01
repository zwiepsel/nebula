using AutoMapper;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Shared.Models.App;
using Nebula.Shared.Models.Client;
using Nebula.Shared.Models.Group;
using Nebula.Shared.Models.Permission;
using Nebula.Shared.Models.Role;
using Nebula.Shared.Models.Security;
using Nebula.Shared.Models.Site;
using Nebula.Shared.Models.SiteUser;
using Nebula.Shared.Models.User;

namespace Nebula.Core.Api.Domain.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        // Apps.
        CreateMap<App, AppViewModel>();
        CreateMap<AppUpdateModel, App>();
        CreateMap<AppCreateModel, App>();

        // Clients.
        CreateMap<Client, ClientViewModel>();
        CreateMap<ClientUpdateModel, Client>();
        CreateMap<ClientCreateModel, Client>();

        // Groups.
        CreateMap<Group, GroupViewModel>();
        CreateMap<GroupUpdateModel, Group>();
        CreateMap<GroupCreateModel, Group>();

        // Permissions.
        CreateMap<Permission, PermissionViewModel>();
        CreateMap<PermissionUpdateModel, Permission>();
        CreateMap<PermissionCreateModel, Permission>();

        // Roles.
        CreateMap<Role, RoleViewModel>();

        // Sites.
        CreateMap<Site, SiteViewModel>();
        CreateMap<SiteUpdateModel, Site>();
        CreateMap<SiteCreateModel, Site>();

        // SiteUsers.
        CreateMap<SiteUser, SiteUserViewModel>().ReverseMap();
        CreateMap<SiteUser, PublicRegisterModel>().ReverseMap();
        CreateMap<SiteUserUpdateModel, SiteUser>().ReverseMap();
        CreateMap<SiteUserCreateModel, SiteUser>().ReverseMap();

        // Users.
        CreateMap<User, UserViewModel>();
        CreateMap<UserUpdateModel, User>();
        CreateMap<UserCreateModel, User>();
    }
}