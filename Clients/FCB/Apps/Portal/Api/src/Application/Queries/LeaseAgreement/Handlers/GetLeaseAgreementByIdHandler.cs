using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.LeaseAgreement.Handlers;

public class GetLeaseAgreementByIdHandler : IRequestHandler<GetLeaseAgreementByIdQuery, Domain.Entities.LeaseAgreement?>
{
    private readonly ILeaseAgreementRepository leaseAgreementRepository;

    public GetLeaseAgreementByIdHandler(ILeaseAgreementRepository leaseAgreementRepository)
    {
        this.leaseAgreementRepository = leaseAgreementRepository;
    }

    public async Task<Domain.Entities.LeaseAgreement?> Handle(GetLeaseAgreementByIdQuery request, CancellationToken cancellationToken)
    {
        return await leaseAgreementRepository.FindById(request.Id);
    }
}