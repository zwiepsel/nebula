using System;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.Rent;

public class RentViewModel : ViewModel
{
    public decimal Amount { get; set; }
    public decimal AskPrice { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal ContractPrice  { get; set; }
    public decimal RentPrice  { get; set; }
    public decimal Discount  { get; set; }
    public decimal PointValue  { get; set; }
}