using System;
using System.Collections.Generic;
using System.Linq;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;
using Nebula.Shared.Models;
using Nebula.Shared.Utilities;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

public class RiskIndexViewModel : ViewModel
{
    public string Name { get; set; } = null!;
    public RiskStatus Status { get; set; }
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

    public int? InherentRiskScore => InherentFrequencyRiskScore != null && InherentImpactRiskScore != null
        ? InherentFrequencyRiskScore.Score * InherentImpactRiskScore.Score
        : null;

    public int? ResidualRiskScore => ResidualFrequencyRiskScore != null && ResidualImpactRiskScore != null
        ? ResidualFrequencyRiskScore.Score * ResidualImpactRiskScore.Score
        : null;

    public string DepartmentsFilter => string.Join('|', Departments.Select(department => HashGenerator.Sha1(department.Id)));
    public DateTime? UpdatedAtFilterFrom => UpdatedAt;
    public DateTime? UpdatedAtFilterTo => UpdatedAt;
}