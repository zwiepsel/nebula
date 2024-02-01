using System.Collections.Generic;
using MediatR;
using Nebula.Core.Api.Application.Queries.Role.Handlers;

namespace Nebula.Core.Api.Application.Queries.Role
{
    /// <see cref="GetCoreRolesHandler"/>
    public class GetCoreRolesQuery : IRequest<IEnumerable<Domain.Entities.Identity.Role>>
    {
    }
}