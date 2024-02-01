using System;
using System.Collections.Generic;
using System.Linq;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.House;
using Nebula.Clients.FCB.Shared.Models.Rent;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.LeaseAgreement;

public class LeaseAgreementViewModel : ViewModel
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public decimal DepositValue { get; set; }

    public DateTime? DepositDate { get; set; }

    public ClientViewModel Client { get; set; } = null!;
    public IList<RentViewModel> Rents { get; set; } = null!;
    public HouseViewModel House { get; set; } = null!;

    public RentViewModel Rent => Rents.OrderByDescending(r => r.CreatedAt).First();
}