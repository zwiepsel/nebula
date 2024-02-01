using MediatR;
using Nebula.Shared.Api.Entities;
using Nebula.Shared.Models;

namespace Nebula.Shared.Api.Commands;

public interface IEntityUpdateCommand<TEntity, TUpdateModel> : IRequest<TEntity>
    where TEntity : IBaseEntity where TUpdateModel : UpdateModel
{
    public TEntity Entity { get; set; }
    public TUpdateModel UpdateModel { get; set; }
}