using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Risk;

/// <see cref="GetAllRisksHandler" />
public class GetAllRisksQuery : IRequest<IList<Domain.Entities.Risk>>
{
}