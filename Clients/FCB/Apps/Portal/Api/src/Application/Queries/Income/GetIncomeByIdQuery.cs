using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Income.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Income;

/// <see cref="GetIncomeByIdHandler" />
public class GetIncomeByIdQuery : IEntityGetByIdQuery<Domain.Entities.Income>
{
    public GetIncomeByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}