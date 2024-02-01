using AutoMapper;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.Complex;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Clients.FCB.Shared.Models.LeaseAgreement;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Clients.FCB.Shared.Models.Rent;
using Nebula.Shared.Clients.Extensions;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        this.CreateMapping<ClientViewModel, ClientUpdateModel>();
        this.CreateMapping<ComplexViewModel, ComplexUpdateModel>();
        this.CreateMapping<LeaseAgreementViewModel, LeaseAgreementUpdateModel>();
        this.CreateMapping<HouseViewModel, HouseUpdateModel>();
        this.CreateMapping<IncomeViewModel, IncomeUpdateModel>();
        this.CreateMapping<NeighborhoodViewModel, NeighborhoodUpdateModel>();
        this.CreateMapping<PersonViewModel, PersonUpdateModel>();
        this.CreateMapping<RentViewModel, RentUpdateModel>();


    }
}