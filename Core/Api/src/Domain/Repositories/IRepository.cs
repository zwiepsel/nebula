using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Core.Api.Domain.Repositories;

public interface IRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
{
}