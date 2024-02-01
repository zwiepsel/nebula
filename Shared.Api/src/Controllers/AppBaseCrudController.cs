using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Api.Queries;
using Nebula.Shared.Api.Utilities;
using Nebula.Shared.Models;
using Nebula.Shared.Models.User;

namespace Nebula.Shared.Api.Controllers;

public abstract class AppBaseCrudController<TEntity,
        TViewModel,
        TCreateModel,
        TUpdateModel,
        TEntityGetByIdQuery,
        TEntityGetAllQuery,
        TEntityCreateCommand,
        TEntityUpdateCommand>
    : BaseCrudController<TEntity,
        TViewModel,
        TCreateModel,
        TUpdateModel,
        TEntityGetByIdQuery,
        TEntityGetAllQuery,
        TEntityCreateCommand,
        TEntityUpdateCommand>
    where TEntity : IBaseEntity
    where TViewModel : ViewModel
    where TCreateModel : CreateModel
    where TUpdateModel : UpdateModel
    where TEntityGetByIdQuery : IEntityGetByIdQuery<TEntity>
    where TEntityGetAllQuery : IEntityGetAllQuery<TEntity>
    where TEntityCreateCommand : IEntityCreateCommand<TEntity, TCreateModel>
    where TEntityUpdateCommand : IEntityUpdateCommand<TEntity, TUpdateModel>
{
    protected AppBaseCrudController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    protected async Task<UserViewModel> GetCurrentUser()
    {
        return await CoreApiHttpClient.Get<UserViewModel>("me/user");
    }
}