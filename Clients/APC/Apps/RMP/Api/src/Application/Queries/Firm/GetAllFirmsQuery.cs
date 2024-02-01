using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Firm;

/// <see cref="GetAllFirmsHandler" />
public class GetAllFirmsQuery : IRequest<IEnumerable<Domain.Entities.Firm>>
{
}