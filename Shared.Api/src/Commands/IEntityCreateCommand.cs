using MediatR;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Models;

namespace Nebula.Shared.Api.Commands;

public interface IEntityCreateCommand<out TEntity, TCreateModel> : IRequest<TEntity>
    where TEntity : IBaseEntity where TCreateModel : CreateModel
{
    public TCreateModel CreateModel { get; set; }
}