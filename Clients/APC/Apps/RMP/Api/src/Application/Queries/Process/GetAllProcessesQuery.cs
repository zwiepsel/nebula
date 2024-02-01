using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Process;

/// <see cref="GetAllProcessesHandler" />
public class GetAllProcessesQuery : IRequest<IEnumerable<Domain.Entities.Process>>
{
}