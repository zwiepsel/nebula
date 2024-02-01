using MediatR;
using Nebula.Core.Api.Application.Queries.User.Handlers;

namespace Nebula.Core.Api.Application.Queries.User;

/// <see cref="GetUserByEmailAddressHandler" />
public class GetUserByEmailAddressQuery : IRequest<Domain.Entities.Identity.User?>
{
    public GetUserByEmailAddressQuery(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; }
}