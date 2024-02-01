using MediatR;
using Nebula.Core.Api.Application.Queries.Site.Handlers;

namespace Nebula.Core.Api.Application.Queries.Site;

/// <see cref="GetSiteByHostHandler" />
public class GetSiteByHostQuery : IRequest<Domain.Entities.Site?>
{
    public GetSiteByHostQuery(string host)
    {
        Host = host;
    }

    public string Host { get; }
}