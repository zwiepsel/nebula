using Microsoft.EntityFrameworkCore;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Shared.Api.Data;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Data;

public interface IDatabaseContext : IBaseDatabaseContext
{
    public DbSet<Coso> Cosos { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<FileType> FileTypes { get; set; }
    public DbSet<Firm> Firms { get; set; }
    public DbSet<MitigationControl> MitigationControls { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<Risk> Risks { get; set; }
    public DbSet<RiskScore> RiskScores { get; set; }
}