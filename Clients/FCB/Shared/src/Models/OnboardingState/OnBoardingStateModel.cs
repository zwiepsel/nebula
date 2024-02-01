using System.Collections.Generic;
using Nebula.Clients.FCB.Shared.Models.Client;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Models;
using Nebula.Shared.Models.Security;

namespace Nebula.Clients.FCB.Shared.Models.OnboardingState;

public class OnBoardingState : ViewModel
{
    public PublicRegisterModel? PublicRegisterModel { get; set; } 
    public ClientCreateModel? ClientCreateModel { get; set; } 
    public PersonCreateModel? PersonCreateModel { get; set; } 
    public List<PersonCreateModel> PersonsToCreate { get; set; } = null!;
    public int FileId { get; set; }
    public int ActiveStep { get; set; } = 1;
    public int IncomeScaleId { get; set; }
    public int AdultQty { get; set; }
    public int ChildrenQty { get; set; }

}