using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Api.Entities;

namespace Nebula.Shared.Api.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public void Add(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity, bool permanent = false);
    public void Restore(TEntity entity);
    public TEntity Refresh(TEntity entity);
    public Task<List<TEntity>> FindAll(CancellationToken cancellationToken = default);
    public Task<List<TEntity>> FindAll(bool includeDeleted, CancellationToken cancellationToken = default);
    public Task<TEntity?> FindById(int id, CancellationToken cancellationToken = default);
    public Task<TEntity?> FindById(int id, bool includeDeleted, CancellationToken cancellationToken = default);
}