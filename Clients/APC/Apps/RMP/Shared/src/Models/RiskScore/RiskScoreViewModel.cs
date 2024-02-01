﻿using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Models;

namespace Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;

public class RiskScoreViewModel : ViewModel
{
    public string Frequency { get; set; } = null!;
    public string Impact { get; set; } = null!;
    public RiskScoreType Type { get; set; }
    public int Score { get; set; }

    public string Name => $"{Frequency} - {Impact}";
}