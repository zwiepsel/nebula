using Nebula.Core.Api.Domain.Data;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Core.Api.Infrastructure.Repositories;

public abstract class Repository<TEntity> : BaseRepository<TEntity, IDatabaseContext> where TEntity : class, IEntity
{
    protected Repository(IDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}