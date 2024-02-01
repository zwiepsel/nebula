using System;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.LeaseAgreement;

public class LeaseAgreementCreateModel : CreateModel
{
    public string Name { get; set; } = null!;

    public decimal DepositValue { get; set; }

    public DateTime? DepositDate { get; set; }
}