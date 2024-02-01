using System.Collections.Generic;
using MediatR;
using Nebula.Core.Api.Application.Queries.Role.Handlers;

namespace Nebula.Core.Api.Application.Queries.Role
{
    /// <see cref="GetSiteRolesHandler"/>
    public class GetSiteRolesQuery : IRequest<IEnumerable<Domain.Entities.Identity.Role>>
    {
    }
}