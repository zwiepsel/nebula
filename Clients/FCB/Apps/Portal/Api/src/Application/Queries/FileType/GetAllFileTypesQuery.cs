using System.Collections.Generic;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.FileType;

/// <see cref="GetAllFileTypesHandler" />
public class GetAllFileTypesQuery : IRequest<IEnumerable<Domain.Entities.FileType>>
{
}