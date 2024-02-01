using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Extensions;
using Nebula.Shared.Api.Data;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Data;

public class DatabaseContext : AppBaseDatabaseContext<DatabaseContext>, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }
    public DbSet<File> Files { get; set; } = null!;
    public DbSet<FileType> FileTypes { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<ClientType> ClientTypes { get; set; } = null!;
    public DbSet<Complex> Complexes { get; set; } = null!;

    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<Income> Incomes { get; set; } = null!;
    public DbSet<IncomeScale> IncomeScales { get; set; } = null!;
    public DbSet<AgeScale> AgeScales { get; set; } = null!;
    public DbSet<ProcessStructure> ProcessStructures { get; set; } = null!;
    public DbSet<ProcessType> ProcessTypes { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; } = null!;
    public DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Rent> Rents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProcessType>().HasOne(processType => processType.RequestType).WithOne().OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        
        // Data seeds.
      //  modelBuilder.SeedPersons();
      //  modelBuilder.SeedLeaseAgreements();
      //  modelBuilder.SeedRents();
      //  modelBuilder.SeedNeighborhoods();
      //  modelBuilder.SeedComplexes();
      //  modelBuilder.SeedIncomes();
        modelBuilder.SeedClientTypes();
        modelBuilder.SeedIncomeScales();
        modelBuilder.SeedAgeScales();
        modelBuilder.SeedFileTypes();
    }
}