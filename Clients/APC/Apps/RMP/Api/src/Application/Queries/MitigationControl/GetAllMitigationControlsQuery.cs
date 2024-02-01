using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.MitigationControl;

/// <see cref="GetAllMitigationControlsHandler" />
public class GetAllMitigationControlsQuery : IRequest<IEnumerable<Domain.Entities.MitigationControl>>
{
}