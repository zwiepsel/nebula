using AutoMapper;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Models.AgeScale;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.ClientType;
using Nebula.Clients.FCB.Shared.Models.Complex;
using Nebula.Clients.FCB.Shared.Models.File;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Clients.FCB.Shared.Models.Income;
using Nebula.Clients.FCB.Shared.Models.IncomeScale;
using Nebula.Clients.FCB.Shared.Models.LeaseAgreement;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Clients.FCB.Shared.Models.Rent;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        this.CreateMapping<ClientType, ClientTypeViewModel, ClientTypeUpdateModel, ClientTypeCreateModel>();
        this.CreateMapping<Client, ClientViewModel,ClientIndexViewModel, ClientUpdateModel, ClientCreateModel>();
        this.CreateMapping<Complex, ComplexViewModel, ComplexUpdateModel, ComplexCreateModel>();
        this.CreateMapping<House, HouseViewModel, HouseIndexViewModel, HouseUpdateModel, HouseCreateModel>();
        this.CreateMapping<Income, IncomeViewModel, IncomeUpdateModel, IncomeCreateModel>();
        this.CreateMapping<LeaseAgreement, LeaseAgreementViewModel, LeaseAgreementUpdateModel, LeaseAgreementCreateModel>();
        this.CreateMapping<Neighborhood, NeighborhoodViewModel, NeighborhoodUpdateModel, NeighborhoodCreateModel>();
        this.CreateMapping<Person, PersonViewModel, PersonIndexViewModel, PersonUpdateModel, PersonCreateModel>();
        this.CreateMapping<Rent, RentViewModel, RentUpdateModel, RentCreateModel>();
        CreateMap<File, FileViewModel>();

        CreateMap<FileType, FileTypeViewModel>();
        CreateMap<FileTypeCreateModel, FileType>();
        CreateMap<FileTypeUpdateModel, FileType>();
        CreateMap<AgeScale, AgeScaleViewModel>().ReverseMap();
        CreateMap<IncomeScale, IncomeScaleViewModel>().ReverseMap();
        CreateMap<PersonViewModel, Person>().ReverseMap();
    }
}