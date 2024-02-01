using System;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Clients.FCB.Shared.Models.Neighborhood;
using Nebula.Shared.Models;
using Nebula.Shared.Utilities;

namespace Nebula.Clients.FCB.Shared.Models.Person;

public class PersonIndexViewModel : ViewModel
{
    public string FirstName { get; set; } = null!;
    public string? Prefix { get; set; }
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime? ApplicantSince { get; set; }
    public int ApplicantNumberOfBedrooms { get; set; }
    public bool ApplicantUrgency { get; set; }
    public bool ApplicantInterestedInBuying { get; set; }
    public bool MainContact { get; set; }
    public RelationType RelationType { get; set; }
    public NeighborhoodViewModel? ApplicantPreferredNeighborhood1 { get; set; }
    public NeighborhoodViewModel? ApplicantPreferredNeighborhood2 { get; set; }
    public NeighborhoodViewModel? ApplicantPreferredNeighborhood3 { get; set; }

    public string FullName { get; set; } = null!;
    public decimal YearlyIncomeAmount { get; set; }
    public string YearlyIncomeClass => GetYearlyIncomeClassDescription();
    public bool Applicant { get; set; }
    public bool Deleted { get; set; }
    public decimal? RentAmount { get; set; }

    public string ApplicantPreferredNeighborhoodFilter =>
        $"{HashGenerator.Sha1(ApplicantPreferredNeighborhood1?.Id)}|{HashGenerator.Sha1(ApplicantPreferredNeighborhood2?.Id)}|{HashGenerator.Sha1(ApplicantPreferredNeighborhood3?.Id)}";

    private int GetYearlyIncomeClass()
    {
        return YearlyIncomeAmount switch
        {
            <= 2793 => 1,
            >= 2793 and < 5587 => 2,
            >= 5587 and < 8380 => 3,
            >= 8380 and < 11173 => 4,
            >= 11173 and < 13966 => 5,
            >= 13966 and < 16760 => 6,
            >= 16760 and < 19553 => 7,
            >= 19553 and < 22346 => 8,
            >= 22347 => 9,
            _ => 0
        };
    }

    private string GetYearlyIncomeClassDescription()
    {
        return GetYearlyIncomeClass() switch
        {
            1 => "1. < 2793",
            2 => "2. 2974 - 5587",
            3 => "3. 5588 - 8380",
            4 => "4. 8381 - 11173",
            5 => "5. 11174 - 13966",
            6 => "6. 13967 - 16760",
            7 => "7. 16761 - 19553",
            8 => "8. 19554 - 22346",
            9 => "9. > 22347",
            _ => "-"
        };
    }
}