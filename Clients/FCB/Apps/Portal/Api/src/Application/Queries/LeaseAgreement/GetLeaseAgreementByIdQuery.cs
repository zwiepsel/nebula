using Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.LeaseAgreement.Handlers;
using Nebula.Shared.Api.Queries;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.LeaseAgreement;

/// <see cref="GetLeaseAgreementByIdHandler" />
public class GetLeaseAgreementByIdQuery : IEntityGetByIdQuery<Domain.Entities.LeaseAgreement>
{
    public GetLeaseAgreementByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}