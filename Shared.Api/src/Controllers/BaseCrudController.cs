using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nebula.Shared.Api.Commands;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Api.Queries;
using Nebula.Shared.Models;

namespace Nebula.Shared.Api.Controllers;

public abstract class BaseCrudController<TEntity,
        TViewModel,
        TCreateModel,
        TUpdateModel,
        TEntityGetByIdQuery,
        TEntityGetAllQuery,
        TEntityCreateCommand,
        TEntityUpdateCommand>
    : BaseController
    where TEntity : IBaseEntity
    where TViewModel : ViewModel
    where TCreateModel : CreateModel
    where TUpdateModel : UpdateModel
    where TEntityGetByIdQuery : IEntityGetByIdQuery<TEntity>
    where TEntityGetAllQuery : IEntityGetAllQuery<TEntity>
    where TEntityCreateCommand : IEntityCreateCommand<TEntity, TCreateModel>
    where TEntityUpdateCommand : IEntityUpdateCommand<TEntity, TUpdateModel>
{
    protected BaseCrudController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    protected async Task<IActionResult> DoGet(int id)
    {
        var query = (TEntityGetByIdQuery)Activator.CreateInstance(typeof(TEntityGetByIdQuery), id)!;
        var entity = await Mediator.Send(query);
        var entityViewModel = Mapper.Map<TViewModel>(entity);

        return Ok(entityViewModel);
    }

    protected async Task<IActionResult> DoGet()
    {
        var query = (TEntityGetAllQuery)Activator.CreateInstance(typeof(TEntityGetAllQuery))!;
        var entities = await Mediator.Send(query);
        var entityViewModels = Mapper.Map<IList<TViewModel>>(entities);

        return Ok(entityViewModels);
    }

    protected async Task<IActionResult> DoGet(TEntityGetAllQuery query)
    {
        var entities = await Mediator.Send(query);
        var entityViewModels = Mapper.Map<IList<TViewModel>>(entities);

        return Ok(entityViewModels);
    }

    protected async Task<IActionResult> DoCreate(TCreateModel createModel)
    {
        var createCommand = (TEntityCreateCommand)Activator.CreateInstance(typeof(TEntityCreateCommand), createModel)!;
        var entity = await Mediator.Send(createCommand);
        var entityViewModel = Mapper.Map<TViewModel>(entity);

        return Ok(entityViewModel);
    }

    protected async Task<IActionResult> DoUpdate(int id, TUpdateModel updateModel)
    {
        if (id != updateModel.Id)
        {
            return BadRequest();
        }


        var query = (TEntityGetByIdQuery)Activator.CreateInstance(typeof(TEntityGetByIdQuery), id)!;
        var entity = await Mediator.Send(query);

        if (entity == null)
        {
            return NotFound();
        }

        var updateCommand = (TEntityUpdateCommand)Activator.CreateInstance(typeof(TEntityUpdateCommand), entity, updateModel)!;

        entity = await Mediator.Send(updateCommand);

        var entityViewModel = Mapper.Map<TViewModel>(entity);

        return Ok(entityViewModel);
    }
}