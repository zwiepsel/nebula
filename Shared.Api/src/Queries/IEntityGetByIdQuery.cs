using MediatR;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Queries;

public interface IEntityGetByIdQuery<out TEntity> : IRequest<TEntity?> where TEntity : IBaseEntity
{
    public int Id { get; }
}