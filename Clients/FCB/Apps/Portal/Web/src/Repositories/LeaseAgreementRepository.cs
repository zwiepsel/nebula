using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Shared.Models.LeaseAgreement;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Repositories;

public class LeaseAgreementRepository : BaseCrudRepository<LeaseAgreementViewModel,
    LeaseAgreementViewModel,
    LeaseAgreementCreateModel,
    LeaseAgreementUpdateModel>
{
    public LeaseAgreementRepository(AppApi api) : base(api, "lease-agreement")
    {
    }
}