using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Core.Api.Domain.Repositories;
using Nebula.Core.Api.Domain.Security;
using Nebula.Shared.Constants;

namespace Nebula.Core.Api.Application.Commands.SiteUser.Handlers;

public class CreateSiteUserHandler : IRequestHandler<CreateSiteUserCommand, Domain.Entities.SiteUser>
{
    private readonly ISiteUserRepository siteUserRepository;
    private readonly IGroupRepository groupRepository;
    private readonly IMapper mapper;
    private readonly PasswordManager passwordManager;
    private readonly RoleManager<Role> roleManager;

    public CreateSiteUserHandler(ISiteUserRepository siteUserRepository, IGroupRepository groupRepository, IMapper mapper, PasswordManager passwordManager, RoleManager<Role> roleManager)
    {
        this.siteUserRepository = siteUserRepository;
        this.groupRepository = groupRepository;
        this.mapper = mapper;
        this.passwordManager = passwordManager;
        this.roleManager = roleManager;
    }

    public async Task<Domain.Entities.SiteUser> Handle(CreateSiteUserCommand request, CancellationToken cancellationToken)
    {
        var site = request.Site;
        var user = request.User;
        var siteUserCreateModel = request.SiteUserCreateModel;
        var publicRegisterModel = request.PublicRegisterModel;

        var siteUser = new Domain.Entities.SiteUser();
        var password = "";

        if (siteUserCreateModel != null)
        {
            siteUser = mapper.Map<Domain.Entities.SiteUser>(siteUserCreateModel);
            password = siteUserCreateModel.Password;

            var siteGroups = await groupRepository.FindBySiteId(site.Id, cancellationToken);

            foreach (var groupId in siteUserCreateModel.GroupCheckboxValues.Where(value => value.Value))
            {
                var group = siteGroups.FirstOrDefault(g => g.Id == groupId.Key);

                if (group != null)
                {
                    siteUser.Groups.Add(group);
                }
            }
        }

        if (publicRegisterModel != null)
        {
            // Public registered users are set to the site user role by default.
            var siteUserRole = await roleManager.Roles.FirstAsync(role => role.Name == SiteRoles.SiteUser, cancellationToken);

            siteUser = mapper.Map<Domain.Entities.SiteUser>(publicRegisterModel);
            siteUser.RoleId = siteUserRole.Id;
            password = publicRegisterModel.Password;
        }

        siteUser.SiteId = site.Id;
        siteUser.UserId = user.Id;

        siteUserRepository.Add(siteUser);
        await siteUserRepository.SaveChangesAsync(cancellationToken);

        await passwordManager.SetPassword(siteUser, password);

        return siteUserRepository.Refresh(siteUser);
    }
}