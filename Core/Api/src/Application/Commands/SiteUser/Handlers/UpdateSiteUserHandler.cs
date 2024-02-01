using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Core.Api.Domain.Repositories;
using Nebula.Core.Api.Domain.Security;

namespace Nebula.Core.Api.Application.Commands.SiteUser.Handlers;

public class UpdateSiteUserHandler : IRequestHandler<UpdateSiteUserCommand, Domain.Entities.SiteUser>
{
    private readonly ISiteUserRepository siteUserRepository;
    private readonly IGroupRepository groupRepository;
    private readonly IMapper mapper;
    private readonly PasswordManager passwordManager;

    public UpdateSiteUserHandler(ISiteUserRepository siteUserRepository, IGroupRepository groupRepository, IMapper mapper, PasswordManager passwordManager)
    {
        this.siteUserRepository = siteUserRepository;
        this.groupRepository = groupRepository;
        this.mapper = mapper;
        this.passwordManager = passwordManager;
    }

    public async Task<Domain.Entities.SiteUser> Handle(UpdateSiteUserCommand request, CancellationToken cancellationToken)
    {
        var siteUserUpdateModel = request.SiteUserUpdateModel;
        var siteUser = mapper.Map(siteUserUpdateModel, request.SiteUser);

        var siteGroups = await groupRepository.FindBySiteId(siteUser.SiteId, cancellationToken);

        foreach (var groupCheckboxValue in siteUserUpdateModel.GroupCheckboxValues)
        {
            var group = siteGroups.FirstOrDefault(g => g.Id == groupCheckboxValue.Key);

            if (group != null)
            {
                // Group checked and not present at the site user, add it.
                if (groupCheckboxValue.Value && siteUser.Groups.All(g => g.Id != group.Id))
                {
                    siteUser.Groups.Add(group);
                }
                // Group not checked and present at the site user, remove it.
                else if (!groupCheckboxValue.Value && siteUser.Groups.Any(g => g.Id == group.Id))
                {
                    siteUser.Groups.Remove(group);
                }
            }
        }

        siteUserRepository.Update(siteUser);
        await siteUserRepository.SaveChangesAsync(cancellationToken);

        if (siteUserUpdateModel.Password != null && siteUserUpdateModel.ConfirmationPassword != null)
        {
            await passwordManager.SetPassword(siteUser, siteUserUpdateModel.Password);
        }

        return siteUser;
    }
}