using MediatR;
using Nebula.Core.Api.Application.Queries.User.Handlers;

namespace Nebula.Core.Api.Application.Queries.User;

/// <see cref="GetUserByUserNameHandler" />
public class GetUserByUserNameQuery : IRequest<Domain.Entities.Identity.User?>
{
    public GetUserByUserNameQuery(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; }
}