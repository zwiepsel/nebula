using System.Collections.Generic;
using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Queries.Department;

/// <see cref="GetAllDepartmentsHandler" />
public class GetAllDepartmentsQuery : IRequest<IEnumerable<Domain.Entities.Department>>
{
}