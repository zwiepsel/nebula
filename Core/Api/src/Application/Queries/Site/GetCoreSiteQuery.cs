using MediatR;
using Nebula.Core.Api.Application.Queries.Site.Handlers;

namespace Nebula.Core.Api.Application.Queries.Site;

/// <see cref="GetCoreSiteHandler" />
public class GetCoreSiteQuery : IRequest<Domain.Entities.Site>
{
}