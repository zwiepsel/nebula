using MediatR;
using Nebula.Core.Api.Application.Commands.SiteUser.Handlers;
using Nebula.Shared.Models.Security;
using Nebula.Shared.Models.SiteUser;

namespace Nebula.Core.Api.Application.Commands.SiteUser;

/// <see cref="CreateSiteUserHandler" />
public class CreateSiteUserCommand : IRequest<Domain.Entities.SiteUser>
{
    public Domain.Entities.Site Site { get; }
    public Domain.Entities.Identity.User User { get; }
    public SiteUserCreateModel? SiteUserCreateModel { get; }
    public PublicRegisterModel? PublicRegisterModel { get; }

    public CreateSiteUserCommand(Domain.Entities.Site site, Domain.Entities.Identity.User user, SiteUserCreateModel siteUserCreateModel)
    {
        Site = site;
        User = user;
        SiteUserCreateModel = siteUserCreateModel;
    }

    public CreateSiteUserCommand(Domain.Entities.Site site, Domain.Entities.Identity.User user, PublicRegisterModel publicRegisterModel)
    {
        Site = site;
        User = user;
        PublicRegisterModel = publicRegisterModel;
    }
}