using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Data;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Extensions;
using Nebula.Shared.Api.Data;
using Nebula.Shared.Api.Extensions;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Data;

public class DatabaseContext : AppBaseDatabaseContext<DatabaseContext>, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    public DbSet<Coso> Cosos { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<File> Files { get; set; } = null!;
    public DbSet<FileType> FileTypes { get; set; } = null!;
    public DbSet<Firm> Firms { get; set; } = null!;
    public DbSet<MitigationControl> MitigationControls { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<Risk> Risks { get; set; } = null!;
    public DbSet<RiskScore> RiskScores { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Temporal tables.
        modelBuilder.EnableTemporalTable<Coso>("Cosos");
        modelBuilder.EnableTemporalTable<Department>("Departments");
        modelBuilder.EnableTemporalTable<File>("Files");
        modelBuilder.EnableTemporalTable<FileType>("FileTypes");
        modelBuilder.EnableTemporalTable<Firm>("Firms");
        modelBuilder.EnableTemporalTable<MitigationControl>("MitigationControls");
        modelBuilder.EnableTemporalTable<Process>("Processes");
        modelBuilder.EnableTemporalTable<Risk>("Risks");
        modelBuilder.EnableTemporalTable<RiskMitigationControl>("RiskMitigationControls");
        modelBuilder.EnableTemporalTable<RiskPossibleOptimization>("RiskPossibleOptimizations");
        modelBuilder.EnableTemporalTable<RiskScore>("RiskScores");

        // Data seeds.
        modelBuilder.SeedProcesses();
        modelBuilder.SeedDepartments();
        modelBuilder.SeedMitigationControls();
        modelBuilder.SeedFileTypes();
        modelBuilder.SeedRiskScores();
        modelBuilder.SeedCosos();
        modelBuilder.SeedFirms();

        base.OnModelCreating(modelBuilder);
    }
}