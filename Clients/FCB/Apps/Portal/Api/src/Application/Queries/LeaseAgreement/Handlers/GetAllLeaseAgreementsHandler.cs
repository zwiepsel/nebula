using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.LeaseAgreement.Handlers;

public class GetAllLeaseAgreementsHandler : IRequestHandler<GetAllLeaseAgreementsQuery, IEnumerable<Domain.Entities.LeaseAgreement>>
{
    private readonly ILeaseAgreementRepository leaseAgreementRepository;

    public GetAllLeaseAgreementsHandler(ILeaseAgreementRepository leaseAgreementRepository)
    {
        this.leaseAgreementRepository = leaseAgreementRepository;
    }

    public async Task<IEnumerable<Domain.Entities.LeaseAgreement>> Handle(GetAllLeaseAgreementsQuery request,
        CancellationToken cancellationToken)
    {
        return await leaseAgreementRepository.FindAll(false, cancellationToken);
    }
}