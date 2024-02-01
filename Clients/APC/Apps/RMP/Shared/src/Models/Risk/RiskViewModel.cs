using System;
using System.Collections.Generic;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.File;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

public class RiskViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public string? ShortName { get; set; }
    public string? StrategicTarget { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? Context { get; set; }
    public string? AdditionalInformation { get; set; }
    public string? Objective { get; set; }
    public RiskStatus Status { get; set; }
    public DateTime? IdentificationDate { get; set; }
    public DateTime? ReviewDate { get; set; }
    public DateTime? ReminderDate { get; set; }
    public RiskScoreType? RiskScoreType { get; set; }

    public int? ProcessId { get; set; }

    public int? InherentFrequencyRiskScoreId { get; set; }
    public RiskScoreViewModel? InherentFrequencyRiskScore { get; set; }

    public int? InherentImpactRiskScoreId { get; set; }
    public RiskScoreViewModel? InherentImpactRiskScore { get; set; }

    public int? ResidualImpactRiskScoreId { get; set; }
    public RiskScoreViewModel? ResidualImpactRiskScore { get; set; }

    public int? ResidualFrequencyRiskScoreId { get; set; }
    public RiskScoreViewModel? ResidualFrequencyRiskScore { get; set; }

    public int? CosoId { get; set; }
    public int? FirmId { get; set; }

    public IList<DepartmentViewModel> Departments { get; set; } = new List<DepartmentViewModel>();
    public IList<RiskMitigationControlViewModel> RiskMitigationControls { get; set; } = new List<RiskMitigationControlViewModel>();
    public IList<RiskPossibleOptimizationViewModel> RiskPossibleOptimizations { get; set; } = new List<RiskPossibleOptimizationViewModel>();
    public IList<RiskViewModel> Revisions { get; set; } = new List<RiskViewModel>();
    public IList<FileViewModel> Files { get; set; } = new List<FileViewModel>();

    public int? InherentRiskScore => InherentFrequencyRiskScore != null && InherentImpactRiskScore != null
        ? InherentFrequencyRiskScore.Score * InherentImpactRiskScore.Score
        : null;

    public int? ResidualRiskScore => ResidualFrequencyRiskScore != null && ResidualImpactRiskScore != null
        ? ResidualFrequencyRiskScore.Score * ResidualImpactRiskScore.Score
        : null;
}