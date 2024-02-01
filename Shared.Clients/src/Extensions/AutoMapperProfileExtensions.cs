using AutoMapper;
using Nebula.Shared.Models;

namespace Nebula.Shared.Clients.Extensions;

public static class AutoMapperProfileExtensions
{
    public static void CreateMapping<TViewModel, TUpdateModel>(this Profile profile)
        where TViewModel : ViewModel where TUpdateModel : UpdateModel
    {
        profile.CreateMap<TViewModel, TUpdateModel>();
        profile.CreateMap<TUpdateModel, TViewModel>();
    }
}