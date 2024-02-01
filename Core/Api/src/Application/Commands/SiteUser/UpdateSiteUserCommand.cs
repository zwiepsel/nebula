using MediatR;
using Nebula.Core.Api.Application.Commands.SiteUser.Handlers;
using Nebula.Shared.Models.SiteUser;

namespace Nebula.Core.Api.Application.Commands.SiteUser;

/// <see cref="UpdateSiteUserHandler" />
public class UpdateSiteUserCommand : IRequest<Domain.Entities.SiteUser>
{
    public Domain.Entities.SiteUser SiteUser { get; }
    public SiteUserUpdateModel SiteUserUpdateModel { get; }

    public UpdateSiteUserCommand(Domain.Entities.SiteUser siteUser, SiteUserUpdateModel siteUserUpdateModel)
    {
        SiteUser = siteUser;
        SiteUserUpdateModel = siteUserUpdateModel;
    }
}