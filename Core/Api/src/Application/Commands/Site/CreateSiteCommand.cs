using Nebula.Core.Api.Application.Commands.Site.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.Site;

namespace Nebula.Core.Api.Application.Commands.Site;

/// <see cref="CreateSiteHandler" />
public class CreateSiteCommand : IEntityCreateCommand<Domain.Entities.Site, SiteCreateModel>
{
    public CreateSiteCommand(SiteCreateModel siteCreateModel)
    {
        CreateModel = siteCreateModel;
    }

    public SiteCreateModel CreateModel { get; set; }
}