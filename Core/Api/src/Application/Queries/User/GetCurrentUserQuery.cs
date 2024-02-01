using MediatR;
using Nebula.Core.Api.Application.Queries.User.Handlers;

namespace Nebula.Core.Api.Application.Queries.User;

/// <see cref="GetCurrentUserHandler" />
public class GetCurrentUserQuery : IRequest<Domain.Entities.Identity.User?>
{
}