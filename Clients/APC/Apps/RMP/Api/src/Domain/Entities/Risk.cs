using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Api.Entities;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;

public class Risk : Entity
{
    public string Name { get; set; } = null!;
    public string? ShortName { get; set; }
    public string? StrategicTarget { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? Context { get; set; }
    public string? AdditionalInformation { get; set; }
    public string? Objective { get; set; }
    public RiskStatus Status { get; set; } = RiskStatus.NotStarted;
    public DateTime? IdentificationDate { get; set; }
    public DateTime? ReviewDate { get; set; }
    public DateTime? ReminderDate { get; set; }
    public RiskScoreType? RiskScoreType { get; set; }

    public int? ProcessId { get; set; }
    public virtual Process? Process { get; set; }

    public int? InherentImpactRiskScoreId { get; set; }
    public virtual RiskScore? InherentImpactRiskScore { get; set; }

    public int? InherentFrequencyRiskScoreId { get; set; }
    public virtual RiskScore? InherentFrequencyRiskScore { get; set; }

    public int? ResidualImpactRiskScoreId { get; set; }
    public virtual RiskScore? ResidualImpactRiskScore { get; set; }

    public int? ResidualFrequencyRiskScoreId { get; set; }
    public virtual RiskScore? ResidualFrequencyRiskScore { get; set; }

    public int? CosoId { get; set; }
    public virtual Coso? Coso { get; set; }

    public int? FirmId { get; set; }
    public virtual Firm? Firm { get; set; }

    public virtual IList<Department> Departments { get; set; } = null!;

    public virtual IList<RiskMitigationControl> RiskMitigationControls { get; set; } = null!;
    public virtual IList<RiskPossibleOptimization> RiskPossibleOptimizations { get; set; } = null!;
    public virtual IList<RiskScore> RiskScores { get; set; } = null!;
    public virtual IList<File> Files { get; set; } = null!;

    [NotMapped]
    public IList<MitigationControl> MitigationControls => RiskMitigationControls.Select(mc => mc.MitigationControl).ToList();

    [NotMapped]
    public IList<MitigationControl> PossibleOptimizations => RiskPossibleOptimizations.Select(mc => mc.MitigationControl).ToList();
}