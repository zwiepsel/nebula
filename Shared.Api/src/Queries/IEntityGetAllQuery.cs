using System.Collections.Generic;
using MediatR;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Queries;

public interface IEntityGetAllQuery<out TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : IBaseEntity
{
}