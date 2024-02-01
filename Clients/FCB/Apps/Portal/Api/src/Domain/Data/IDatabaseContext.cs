using Microsoft.EntityFrameworkCore;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Shared.Api.Data;
using Client = Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;

public interface IDatabaseContext : IBaseDatabaseContext
{
    public DbSet<File> Files { get; set; }
    public DbSet<FileType> FileTypes { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientType> ClientTypes { get; set; } 
    public DbSet<Complex> Complexes { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<IncomeScale> IncomeScales { get; set; }
    public DbSet<ProcessStructure> ProcessStructures { get; set; }
    public DbSet<ProcessType> ProcessTypes { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<AgeScale> AgeScales { get; set; }
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
    public DbSet<Neighborhood> Neighborhoods { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Rent> Rents { get; set; }
}