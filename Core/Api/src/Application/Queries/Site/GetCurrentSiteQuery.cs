using MediatR;
using Nebula.Core.Api.Application.Queries.Site.Handlers;

namespace Nebula.Core.Api.Application.Queries.Site;

/// <see cref="GetCurrentSiteHandler" />
public class GetCurrentSiteQuery : IRequest<Domain.Entities.Site?>
{
}