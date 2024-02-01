using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.File;

/// <see cref="GetAllFilesHandler" />
public class GetAllFilesQuery : IRequest<IList<Domain.Entities.File>>
{
}