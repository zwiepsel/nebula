using MediatR;
using Nebula.Core.Api.Application.Queries.Role.Handlers;

namespace Nebula.Core.Api.Application.Queries.Role;

/// <see cref="GetRoleByNameHandler"/>
public class GetRoleByNameQuery : IRequest<Domain.Entities.Identity.Role>
{
    public string RoleName { get; }

    public GetRoleByNameQuery(string roleName)
    {
        RoleName = roleName;
    }
}