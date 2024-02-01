using Microsoft.EntityFrameworkCore;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedProcesses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Process>().HasData(
            new Process { Id = 1, Name = "Process 1", CreatedById = 1 },
            new Process { Id = 2, Name = "Process 2", CreatedById = 1 },
            new Process { Id = 3, Name = "Process 3", CreatedById = 1 }
        );
    }

    public static void SeedDepartments(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Department 1", CreatedById = 1 },
            new Department { Id = 2, Name = "Department 2", CreatedById = 1 },
            new Department { Id = 3, Name = "Department 3", CreatedById = 1 }
        );
    }

    public static void SeedMitigationControls(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MitigationControl>().HasData(
            new MitigationControl
            {
                Id = 1,
                Name = "Mitigation control 1",
                ShortName = "MC1",
                Description = "Description 1",
                ControlType = MitigationControlType.Preventive,
                Trigger = MitigationControlTrigger.Daily,
                CreatedById = 1
            },
            new MitigationControl
            {
                Id = 2,
                Name = "Mitigation control 2",
                ShortName = "MC2",
                Description = "Description 2",
                ControlType = MitigationControlType.Detective,
                Trigger = MitigationControlTrigger.Weekly,
                CreatedById = 1
            },
            new MitigationControl
            {
                Id = 3,
                Name = "Mitigation control 3",
                ShortName = "MC3",
                Description = "Description 3",
                ControlType = MitigationControlType.Corrective,
                Trigger = MitigationControlTrigger.Monthly,
                CreatedById = 1
            }
        );
    }

    public static void SeedFileTypes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileType>().HasData(
            new FileType { Id = 1, Name = "File type 1", CreatedById = 1 },
            new FileType { Id = 2, Name = "File type 2", CreatedById = 1 },
            new FileType { Id = 3, Name = "File type 3", CreatedById = 1 }
        );
    }

    public static void SeedRiskScores(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RiskScore>().HasData(
            new RiskScore
            {
                Id = 1,
                Frequency = "< 3 years",
                Impact = "< Nafl 500K",
                Type = RiskScoreType.Investment,
                Score = 1,
                CreatedById = 1
            },
            new RiskScore
            {
                Id = 2,
                Frequency = "1 year >< 3 years",
                Impact = "Nafl 500K >< Nafl 2.5Mln",
                Type = RiskScoreType.Investment,
                Score = 2,
                CreatedById = 1
            },
            new RiskScore
            {
                Id = 3,
                Frequency = "< 1 year",
                Impact = "> Nafl 2.5Mln",
                Type = RiskScoreType.Investment,
                Score = 3,
                CreatedById = 1
            },
            new RiskScore
            {
                Id = 4,
                Frequency = "< 2 years",
                Impact = "< Nafl 50K",
                Type = RiskScoreType.Operational,
                Score = 1,
                CreatedById = 1
            },
            new RiskScore
            {
                Id = 5,
                Frequency = "< 1 years",
                Impact = "Nafl 50K >< Nafl 100K",
                Type = RiskScoreType.Operational,
                Score = 2,
                CreatedById = 1
            },
            new RiskScore
            {
                Id = 6,
                Frequency = "< 0.5 year",
                Impact = "> Nafl 100K",
                Type = RiskScoreType.Operational,
                Score = 3,
                CreatedById = 1
            }
        );
    }

    public static void SeedCosos(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coso>().HasData(
            new Coso { Id = 1, Name = "Strategisch risico", CreatedById = 1 },
            new Coso { Id = 2, Name = "Operationeel risico", CreatedById = 1 },
            new Coso { Id = 3, Name = "Verslaggevingsrisico", CreatedById = 1 },
            new Coso { Id = 4, Name = "Compliance risico", CreatedById = 1 }
        );
    }

    public static void SeedFirms(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Firm>().HasData(
            new Firm { Id = 1, Name = "Marktrisico", CreatedById = 1 },
            new Firm { Id = 2, Name = "Kredietrisico", CreatedById = 1 },
            new Firm { Id = 3, Name = "Omgevingsrisico", CreatedById = 1 },
            new Firm { Id = 4, Name = "Operationeel risico", CreatedById = 1 },
            new Firm { Id = 5, Name = "Uitbestedingsrisico", CreatedById = 1 },
            new Firm { Id = 6, Name = "IT risico", CreatedById = 1 },
            new Firm { Id = 7, Name = "Model risico", CreatedById = 1 },
            new Firm { Id = 8, Name = "Juridisch risico", CreatedById = 1 },
            new Firm { Id = 9, Name = "Integriteit risico", CreatedById = 1 }
        );
    }
}