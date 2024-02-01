using AutoMapper;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Clients.FCB.Shared.Models.User;
using Nebula.Shared.Clients.Extensions;
using Nebula.Shared.Models.Security;

namespace Nebula.Clients.FCB.Sites.MyFCB.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<PublicRegisterModel, RegisterUserModel>().ReverseMap();

        this.CreateMapping<PersonViewModel, PersonUpdateModel>();

    }
}