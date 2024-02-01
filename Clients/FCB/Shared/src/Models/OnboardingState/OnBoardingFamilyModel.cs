using System.Collections.Generic;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Models;

namespace Nebula.Clients.FCB.Shared.Models.OnboardingState;

public class OnBoardingFamilyModel : ViewModel
{
    public List<PersonCreateModel> Adults { get; set; } = new();
    public List<PersonCreateModel> Children { get; set; } = new();
    public PersonCreateModel MainContact { get; set; } = null!;
    public int ClientId { get; set; }
}