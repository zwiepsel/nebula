using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Coso;

/// <see cref="GetAllCososHandler" />
public class GetAllCososQuery : IRequest<IEnumerable<Domain.Entities.Coso>>
{
}