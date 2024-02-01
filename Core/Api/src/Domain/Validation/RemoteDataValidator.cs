using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Application.Queries.Group;
using Nebula.Core.Api.Application.Queries.Permission;
using Nebula.Core.Api.Application.Queries.Site;
using Nebula.Core.Shared.Validation;

namespace Nebula.Core.Api.Domain.Validation;

public class RemoteDataValidator : IRemoteDataValidator
{
    private readonly IMediator mediator;

    public RemoteDataValidator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<bool> UniquePermissionSystemName(string permissionSystemName)
    {
        var currentSite = await mediator.Send(new GetCurrentSiteQuery());

        if (currentSite != null)
        {
            var permission = await mediator.Send(new GetPermissionBySiteIdAndSystemNameQuery(currentSite.Id, permissionSystemName));

            if (permission == null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<bool> UniqueGroupSystemName(string groupSystemName)
    {
        var currentSite = await mediator.Send(new GetCurrentSiteQuery());

        if (currentSite != null)
        {
            var group = await mediator.Send(new GetGroupBySiteIdAndSystemNameQuery(currentSite.Id, groupSystemName));

            if (group == null)
            {
                return true;
            }
        }

        return false;
    }
}