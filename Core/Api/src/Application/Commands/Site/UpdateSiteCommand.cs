using Nebula.Core.Api.Application.Commands.Site.Handlers;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Models.Site;

namespace Nebula.Core.Api.Application.Commands.Site;

/// <see cref="UpdateSiteHandler" />
public class UpdateSiteCommand : IEntityUpdateCommand<Domain.Entities.Site, SiteUpdateModel>
{
    public UpdateSiteCommand(Domain.Entities.Site site, SiteUpdateModel siteUpdateModel)
    {
        Entity = site;
        UpdateModel = siteUpdateModel;
    }

    public Domain.Entities.Site Entity { get; set; }
    public SiteUpdateModel UpdateModel { get; set; }
}