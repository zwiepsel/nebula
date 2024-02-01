using System;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;

public class RiskUpdateModel : UpdateModel
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
    public int? InherentImpactRiskScoreId { get; set; }
    public int? InherentFrequencyRiskScoreId { get; set; }
    public int? ResidualImpactRiskScoreId { get; set; }
    public int? ResidualFrequencyRiskScoreId { get; set; }
    public int? CosoId { get; set; }
    public int? FirmId { get; set; }
}