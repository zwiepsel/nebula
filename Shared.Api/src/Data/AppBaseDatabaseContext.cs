using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Nebula.Shared.Api.Data;

public abstract class AppBaseDatabaseContext<TDatabaseContext> : BaseDatabaseContext<TDatabaseContext> where TDatabaseContext : DbContext
{
    protected AppBaseDatabaseContext(DbContextOptions<TDatabaseContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }
}