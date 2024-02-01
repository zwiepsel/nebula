using AutoMapper;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Models;

namespace Nebula.Shared.Api.Extensions;

public static class AutoMapperProfileExtensions
{
    public static void CreateMapping<TEntity, TViewModel, TUpdateModel, TCreateModel>(this Profile profile)
        where TEntity : IBaseEntity
        where TViewModel : ViewModel
        where TUpdateModel : UpdateModel
        where TCreateModel : CreateModel
    {
        profile.CreateMap<TEntity, TViewModel>();
        profile.CreateMap<TUpdateModel, TEntity>();
        profile.CreateMap<TCreateModel, TEntity>();
    }

    public static void CreateMapping<TEntity, TViewModel, TIndexViewModel, TUpdateModel, TCreateModel>(this Profile profile)
        where TEntity : IBaseEntity
        where TViewModel : ViewModel
        where TIndexViewModel : ViewModel
        where TUpdateModel : UpdateModel
        where TCreateModel : CreateModel
    {
        profile.CreateMap<TEntity, TViewModel>();
        profile.CreateMap<TEntity, TIndexViewModel>();
        profile.CreateMap<TUpdateModel, TEntity>();
        profile.CreateMap<TCreateModel, TEntity>();
    }
}