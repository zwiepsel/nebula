using System.Collections.Generic;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.File;

/// <see cref="GetAllFilesHandler" />
public class GetAllFilesQuery : IRequest<IList<Domain.Entities.File>>
{
}