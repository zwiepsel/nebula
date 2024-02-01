using MediatR;
using Nebula.Core.Api.Application.Queries.Security.Handlers;

namespace Nebula.Core.Api.Application.Queries.Security;

/// <see cref="IsValidPasswordHandler" />
public class IsValidPasswordQuery : IRequest<bool>
{
    public Domain.Entities.Identity.User? User { get; }
    public Domain.Entities.SiteUser? SiteUser { get; }
    public string Password { get; }

    public IsValidPasswordQuery(Domain.Entities.Identity.User user, string password)
    {
        User = user;
        Password = password;
    }

    public IsValidPasswordQuery(Domain.Entities.SiteUser siteUser, string password)
    {
        SiteUser = siteUser;
        Password = password;
    }
}