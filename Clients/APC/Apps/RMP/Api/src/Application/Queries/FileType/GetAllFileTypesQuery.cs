using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.FileType.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.FileType;

/// <see cref="GetAllFileTypesHandler" />
public class GetAllFileTypesQuery : IRequest<IEnumerable<Domain.Entities.FileType>>
{
}